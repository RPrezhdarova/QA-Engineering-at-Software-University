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
    public class BrandApiTests : IDisposable
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
        public void Test_GetAllBrands()
        {
            //Arrange
            var request = new RestRequest("brand", Method.Get);
           

            //Act
            var response = client.Execute(request);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var brands = JArray.Parse(response.Content);
                Assert.That(brands.Type, Is.EqualTo(JTokenType.Array));
                Assert.That(brands.Count, Is.GreaterThan(5));

                var firstBrand = brands.FirstOrDefault();
                Assert.That(firstBrand, Is.Not.Null);

                var brandNames = brands.Select(b => b["title"]?.ToString()).ToList();
                Assert.That(brandNames, Does.Contain("TechCorp"));
                Assert.That(brandNames, Does.Contain("GameMaster"));


                foreach (var brand in brands)
                {
                    Assert.That(brand["_id"]?.ToString(), Is.Not.Null.And.Not.Empty);
                    Assert.That(brand["title"]?.ToString(), Is.Not.Null.And.Not.Empty);                 
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddBrand()
        {
            //Arrange
            var request = new RestRequest("brand", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "New Brand Title",
                
            });

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var content = JObject.Parse(response.Content);
                Assert.That(content["title"].ToString(), Is.EqualTo("New Brand Title"));
                Assert.That(content["_id"].ToString(), Is.Not.Null.Or.Empty);
            });

        }
        [Test, Order(3)]
        public void Test_UpdateBrand()
        {
            var request = new RestRequest("brand", Method.Get);
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Empty);

            var brands = JArray.Parse(response.Content);
            var brandToUpdate = brands.FirstOrDefault(b => b["title"].ToString() == "New Brand Title");

            var brandId = brandToUpdate["_id"].ToString();

            var updateRequest = new RestRequest("brand/{id}", Method.Put);
            updateRequest.AddUrlSegment("id", brandId);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(new
            {
                title = "Updated Brand Title"
                
            });

            //Act
            GlobalConstants.UserWait();
            var updateResponse = client.Execute(updateRequest);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(updateResponse.Content, Is.Not.Empty);

                var content = JObject.Parse(updateResponse.Content);

                Assert.That(content["_id"].ToString(), Is.EqualTo(brandId));
                Assert.That(content["title"].ToString(), Is.EqualTo("Updated Brand Title"));
                Assert.That(content.ContainsKey("createdAt"), Is.True);
                Assert.That(content.ContainsKey("updatedAt"), Is.True);
                Assert.That(content["createdAt"].ToString(), Is.Not.EqualTo(content["updatedAt"].ToString()));
            });
        }

        [Test, Order(4)]
        public void Test_DeleteBrand()
        {
            //Arrange
            var getRequest = new RestRequest("brand", Method.Get);

            //Act
            var getResponse = client.Execute(getRequest);
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not Ok");
            Assert.That(getResponse.Content, Is.Not.Empty, "Response content is empty");

            var brands = JArray.Parse(getResponse.Content);
            var brandToDelete = brands.FirstOrDefault(p => p["title"].ToString() == "Updated Brand Title");

            Assert.That(brandToDelete, Is.Not.Null);

            var brandId = brandToDelete["_id"]?.ToString();
            var deleteRequest = new RestRequest("brand/{id}", Method.Delete);
            deleteRequest.AddUrlSegment("id", brandId);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteResponse = client.Execute(deleteRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var verifyGetRequest = new RestRequest("brand/{id}", Method.Get);
            verifyGetRequest.AddUrlSegment("id", brandId);

            var verifyResponse = client.Execute(verifyGetRequest);

            Assert.That(verifyResponse.Content, Is.EqualTo("null"));

        }
    }
}
