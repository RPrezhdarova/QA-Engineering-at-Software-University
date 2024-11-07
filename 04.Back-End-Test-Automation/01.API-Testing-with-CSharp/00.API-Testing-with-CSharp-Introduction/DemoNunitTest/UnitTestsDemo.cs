using Demo_API_Testing;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;

namespace DemoNunitTest
{
    public class UnitTestsDemo
    {
        RestClient client;

        [SetUp]
        public void Setup()
        {
            var options = new RestClientOptions("https://api.github.com")
            {
                MaxTimeout = 3000,
                Authenticator = new HttpBasicAuthenticator("RPrezhdarova", "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")

        };
            this.client = new RestClient(options);
            
        }

        [Test]
        public void Test_GithubApiRequest()
        {
     
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Get);
           // request.Timeout = TimeSpan.FromMilliseconds(1000);

            var response = client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not as expected");
        }

        [Test]
        public void Test_CreateNewIssue() {
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues");
            request.AddBody(new { title = "SomeRandomTitle123", body = "SomeRandomBody123" });
            var response = client.Post(request);
            var issue = JsonSerializer.Deserialize<Issue>(response.Content);
            Assert.That(issue.id, Is.GreaterThan(0));
            Assert.That(issue.number, Is.GreaterThan(0));
            Assert.That(issue.title, Is.EqualTo("SomeRandomTitle123"));
            Assert.That(issue.body, Is.EqualTo("SomeRandomBody123"));

        }


    }
}