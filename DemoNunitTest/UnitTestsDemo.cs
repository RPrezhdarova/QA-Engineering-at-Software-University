using DemoNunitTest.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;

namespace DemoNunitTest
{
    public class UnitTestsDemo
    {
        RestClient client;
        string issueEndpoint = "/repos/testnakov/test-nakov-repo/issues";
        Random random;
        int createdIssueNumber;


        [SetUp]
        public void Setup()
        {
            var options = new RestClientOptions("https://api.github.com")
            {
                MaxTimeout = 3000,
                Authenticator = new HttpBasicAuthenticator("RPrezhdarova", "ghp_HV1...")
            };
            this.client = new RestClient(options);
            random = new Random();
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
            var request = new RestRequest(issueEndpoint);
            request.AddBody(new { title = "SomeRandomTitle123", body = "SomeRandomBody123" });
            var response = client.Post(request);
            var issue = System.Text.Json.JsonSerializer.Deserialize<Issue>(response.Content);
            Assert.That(issue.id, Is.GreaterThan(0));
            Assert.That(issue.number, Is.GreaterThan(0));
            Assert.That(issue.title, Is.EqualTo("SomeRandomTitle123"));
            Assert.That(issue.body, Is.EqualTo("SomeRandomBody123"));

        }
        [Test]
        public void Test_GetAllIssuesAPIRequest()
        {
            //Arrange
            var request = new RestRequest(issueEndpoint, Method.Get);

            //Act
            var response = this.client.Execute(request);
            var issues = JsonConvert.DeserializeObject<List<Issue>>(response.Content);
            

            //Assert
            Assert.That(issues.Count > 1);
            foreach ( var issue in issues)
            {
                Assert.That(issue.id, Is.GreaterThan(0));
                Assert.That(issue.number, Is.GreaterThan(0));
                Assert.That(issue.title, Is.Not.Empty);
            }      
        }

        [Test]
        public void Test_CreateGitHubIssue()
        {
            //Arrange
            string title = generateRandomStringByPrefix("Title");
            string body = generateRandomStringByPrefix("Body");

            //Act
            var issue = CreateIssue(title, body);
            createdIssueNumber = issue.number;

            //Assert
            Assert.That(issue.id, Is.GreaterThan(0));
            Assert.That(issue.number, Is.GreaterThan(0));
            Assert.That(issue.title, Is.EqualTo(title));
            Assert.That(issue.body, Is.EqualTo(body));

        }

        [Test]
        public void Test_UpdateGitHubIssue()
        {
            string updatedTitle = "Updated title";
            var request = new RestRequest(issueEndpoint + "/" + createdIssueNumber.ToString());
            request.AddBody(new { title = updatedTitle });
            var response = client.Execute(request, Method.Patch);
            var issue = JsonConvert.DeserializeObject<Issue>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(issue.id, Is.GreaterThan(0));
            Assert.That(issue.number, Is.GreaterThan(0));
            Assert.That(issue.title, Is.EqualTo(updatedTitle));

        }
        private Issue CreateIssue(string title, string body)
        {
            var request = new RestRequest(issueEndpoint);
            request.AddBody(new { body, title });
            var response = this.client.Execute(request, Method.Post);    
            var issue = JsonConvert.DeserializeObject<Issue>(response.Content);
            return issue;
        }
        public string generateRandomStringByPrefix(string prefix)
        {
            int randomNumber = random.Next(9999, 1000000);
            return prefix + randomNumber; 
        }

    }
}