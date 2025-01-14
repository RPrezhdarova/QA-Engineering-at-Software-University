using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        string repoName = "test-nakov-repo";
        int lastCreatedIssueNumber;
        long lastCreatedCommentId;

        [SetUp]
        public void Setup()
        {            
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "RPrezhdarova", "apiKey");
        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        {
           
            //Act
            var issues = client.GetAllIssues(repoName);

            //Assert

            Assert.That(issues, Has.Count.GreaterThan(0), "There should be more then one issue");
            foreach( var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue id should be bigger than 0");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue number should be bigger than 0");
                Assert.That(issue.Title, Is.Not.Empty, "Issue title should not be empty");
            }
        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            //Arrange
            int issueNumber = 1;

            //Act
            var issue = client.GetIssueByNumber(repoName, issueNumber);

            //Assert
            Assert.IsNotNull(issue, "The data from the response should not be null");
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue id should be greated than 0");
            Assert.That(issue.Number, Is.GreaterThan(0), "Issue number should be greated than 0");
        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            //arrange
            int issueNumber = 6;
            
            //Act
            var lables = client.GetAllLabelsForIssue(repoName, issueNumber);

            //Assert
            Assert.That(lables, Has.Count.GreaterThan(0), "Lables count should be greated than 0");
            foreach (var label in lables)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(label.Id, Is.GreaterThan(0), "Lable id should be bigger than 0");
                    Assert.That(label.Name, Is.Not.Empty, "Lable name shoud not be empty");
                });
                Console.WriteLine("Label: " + label.Id + " - " + label.Name);
            }
        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            //Arrange
            int issueNumber = 6;

            //Act
            var comments = client.GetAllCommentsForIssue(repoName,issueNumber);

            //Assert
            Assert.That(comments, Has.Count.GreaterThan(0), "Comments count should be bigger than 0");
            foreach(var comment in comments)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(comment.Id, Is.GreaterThan(0), "Comment Id should be greater than 0");
                    Assert.That(comment.Body, Is.Not.Empty, "Comment body should not be empty");
                });
                Console.WriteLine("Comment: " + comment.Id + " - Body:" + comment.Body);
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            //Arrange
            string title = "Some Random Title";
            string body = "Some Random Body";

            //Act
            var issue = client.CreateIssue(repoName, title, body);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue id should be bigger than 0");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue number should be bigger than 0");
                Assert.That(issue.Title, Is.EqualTo(title));
                Assert.That(issue.Body, Is.EqualTo(body));
            });
            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;

        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            //Arrange
            var commentBody = "Some Comment";

            //Act
            var comment = client.CreateCommentOnGitHubIssue(repoName, lastCreatedIssueNumber, commentBody);

            //Assert
            Assert.That(comment.Body, Is.EqualTo(commentBody));

            Console.WriteLine(comment.Id);
            lastCreatedCommentId= comment.Id;

        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            //Act
            var comment = client.GetCommentById(repoName, lastCreatedCommentId);

            //Assert
            Assert.IsNotNull(comment);
            Assert.That(comment.Id, Is.EqualTo(lastCreatedCommentId));
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            //Arrange
            string newBody = "Some New Body";

            //Act
            var comment = client.EditCommentOnGitHubIssue(repoName, lastCreatedCommentId, newBody);

            //Assert
            Assert.IsNotNull(comment);
            Assert.That(comment.Id, Is.EqualTo(lastCreatedCommentId));
            Assert.That(comment.Body, Is.EqualTo(newBody));
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            //Act
            var result = client.DeleteCommentOnGitHubIssue(repoName, lastCreatedCommentId);

            //Assert
            Assert.IsTrue(result, "The comment should be successfully deleted");
        }


    }
}

