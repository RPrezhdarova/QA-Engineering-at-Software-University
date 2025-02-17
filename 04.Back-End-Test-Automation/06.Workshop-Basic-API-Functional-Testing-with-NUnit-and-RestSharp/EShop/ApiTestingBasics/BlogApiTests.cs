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
    public class BlogApiTests : IDisposable
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
        public void Test_GetAllBlogs()
        {
            //Arrange
            var request = new RestRequest("blog", Method.Get);

            //Act
            var response = client.Execute(request);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var blogs = JArray.Parse(response.Content);
                Assert.That(blogs.Count, Is.GreaterThan(0));
                
                foreach ( var blog in blogs)
                {
                    Assert.That(blog["title"]?.ToString(), Is.Not.Null.And.Not.Empty);
                    Assert.That(blog["description"]?.ToString(), Is.Not.Null.And.Not.Empty);
                    Assert.That(blog["author"]?.ToString(), Is.Not.Null.And.Not.Empty);
                    Assert.That(blog["category"]?.ToString(), Is.Not.Null.And.Not.Empty);
                }
            });

        }

        [Test, Order(2)]
        public void Test_AddBlog()
        {
            //Arrange
            var request = new RestRequest("blog", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "New Blog Title", 
                description = "New Description", 
                category = "New category test"
            });

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var content = JObject.Parse(response.Content);
                Assert.That(content["title"].ToString(), Is.EqualTo("New Blog Title"));       
                Assert.That(content["description"].ToString(), Is.EqualTo("New Description"));               
                Assert.That(content["category"].ToString(), Is.EqualTo("New category test"));
                Assert.That(content["author"].ToString(), Is.Not.Null.And.Not.Empty);
            });
        }

        [Test, Order(3)]
        public void Test_UpdateBlog()
        {
    
            var request = new RestRequest("blog", Method.Get);     
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Empty);

            var blogs = JArray.Parse(response.Content);
            var blogToUpdate = blogs.FirstOrDefault(b => b["title"].ToString() == "New Blog Title");

            var blogId = blogToUpdate["_id"].ToString();

            var updateRequest = new RestRequest("blog/{id}", Method.Put);
            updateRequest.AddUrlSegment("id", blogId);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(new
            {
                title = "Updated Blog Title",
                description = "updated Description",
                category = "updated category test"
            });

            //Act            
            var updateResponse = client.Execute(updateRequest);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(updateResponse.Content, Is.Not.Empty);

                var content = JObject.Parse(updateResponse.Content);

                Assert.That(content["title"].ToString(), Is.EqualTo("Updated Blog Title"));
                Assert.That(content["description"].ToString(), Is.EqualTo("updated Description"));
                Assert.That(content["category"].ToString(), Is.EqualTo("updated category test"));
                Assert.That(content["author"].ToString(), Is.Not.Null.And.Not.Empty);

            });
        }

        [Test, Order(4)]
        public void Test_DeleteBlog()
        {
            //Arrange
            var getRequest = new RestRequest("blog", Method.Get);

            //Act
            var getResponse = client.Execute(getRequest);
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not Ok");
            Assert.That(getResponse.Content, Is.Not.Empty, "Response content is empty");

            var blogs = JArray.Parse(getResponse.Content);
            var blogToDelete = blogs.FirstOrDefault(p => p["title"].ToString() == "Updated Blog Title");

            Assert.That(blogToDelete, Is.Not.Null);

            var blogId = blogToDelete["_id"]?.ToString();
            var deleteRequest = new RestRequest("blog/{id}", Method.Delete);
            deleteRequest.AddUrlSegment("id", blogId);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteResponse = client.Execute(deleteRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var verifyGetRequest = new RestRequest("blog/{id}", Method.Get);
            verifyGetRequest.AddUrlSegment("id", blogId);

            var verifyResponse = client.Execute(verifyGetRequest);

            Assert.That(verifyResponse.Content, Is.EqualTo("null"));

        }
    }
}
