using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingBasics
{
    [TestFixture]
    public class ProductApiTests : IDisposable
    {
        private RestClient client;
        private string token;

        public object HttpResponseStatus { get; private set; }

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("admin@gmail.com", "admin@gmail.com");

            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token is null or empty");

        }
        public void Dispose()
        {
            client?.Dispose();
        }

        [Test, Order(1)] 
        public void Test_GetAllProducts()
        {
            //Arrange
            var request = new RestRequest("product", Method.Get);

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not Ok");
                Assert.That(response.Content, Is.Not.Empty, "Response content is empty");

                var content = JArray.Parse(response.Content);

                var productTitle = new[]
                {
                    "Smartphone Alpha", "Wireless Headphones", "Gaming Laptop", "4K Ultra HD TV", "Smartwatch Pro"
                };
                foreach (var title in productTitle)
                {
                    Assert.That(content.ToString(), Does.Contain(title));
                }
                var expectedPrices = new Dictionary<string, decimal>
                {
                    {"Smartphone Alpha", 999 },
                    {"Wireless Headphones", 199 },
                    {"Gaming Laptop", 1499 },
                    {"4K Ultra HD TV", 899 },
                    {"Smartwatch Pro", 299 }
                };

                foreach(var product in content)
                {
                    var title = product["title"].ToString();
                    if (expectedPrices.ContainsKey(title))
                    {
                        Assert.That(product["price"].Value<decimal>(), Is.EqualTo(expectedPrices[title]));
                    }
                }
                });
        }

        [Test, Order(2)]
        public void Test_AddProduct()
        {
            //Arrange
            var request = new RestRequest("product", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "New Test Product4",
                slug = "new-test-product4", 
                description="description",
                price = 99.99,
                category = "test category",
                brand = "Test Brand",
                quantity = 50
            });

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var content = JObject.Parse(response.Content);
                Assert.That(content["title"].ToString(), Is.EqualTo("New Test Product4"));
                Assert.That(content["slug"].ToString(), Is.EqualTo("new-test-product4"));
                Assert.That(content["description"].ToString(), Is.EqualTo("description"));
                Assert.That(content["price"].Value<decimal>(), Is.EqualTo(99.99));
                Assert.That(content["category"].ToString(), Is.EqualTo("test category"));
                Assert.That(content["brand"].ToString(), Is.EqualTo("Test Brand"));
                Assert.That(content["quantity"].Value<int>(), Is.EqualTo(50));
            });


        }

        [Test, Order(3)]
        public void Test_UpdateProduct_InvalidProductId()
        {
            //Arrange
            var invalidId = "InvalidID";
            var updateRequest = new RestRequest("product/{id}", Method.Put);
            updateRequest.AddUrlSegment("id", invalidId);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(new
            {
                title = "Updated Test Product3",
                slug = "updated-test-product3",
                description = "Updated description",
                price = 99.99,
                category = "test category",
                brand = "Test Brand",
                quantity = 50
            });

            //Act
            var updatedResponse = client.Execute(updateRequest);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(updatedResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError).Or.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(updatedResponse.Content, Does.Contain("This id is not valid or not Found").Or.Contain("Invalid Id"));
            
            });

        }

        [Test, Order(4)]
        public void Test_DeleteProduct()
        {
            //Arrange
            var getRequest = new RestRequest("product", Method.Get);

            //Act
            var getResponse = client.Execute(getRequest);
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not Ok");
            Assert.That(getResponse.Content, Is.Not.Empty, "Response content is empty");

            var products = JArray.Parse(getResponse.Content);
            var productToDelete = products.FirstOrDefault(p => p["slug"].ToString() == "new-test-product4");

            Assert.That(productToDelete, Is.Not.Null);

            var productId = productToDelete["_id"]?.ToString();
            var deleteRequest = new RestRequest("product/{id}", Method.Delete);
            deleteRequest.AddUrlSegment("id", productId);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteResponse = client.Execute(deleteRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var verifyGetRequest = new RestRequest("product/{id}", Method.Get);
            verifyGetRequest.AddUrlSegment("id", productId);

            var verifyResponse = client.Execute(verifyGetRequest);

            Assert.That(verifyResponse.Content, Is.EqualTo("null"));


        }
    }
}
