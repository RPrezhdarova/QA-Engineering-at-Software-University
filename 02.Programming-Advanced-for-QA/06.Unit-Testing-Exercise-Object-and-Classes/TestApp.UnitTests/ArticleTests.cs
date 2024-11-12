using NUnit.Framework;

using System;
using System.Reflection.Metadata;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;
    private string[] articles;
    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange   
        articles = new string[]
            {
           "Article Content Author",
           "Article2 Content2 Author2",
           "Article3 Content3 Author3"
            };
        // Act
        Article result = _article.AddArticles(articles);
        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        articles = new string[]
                 {
                "C_Title Content1 Author1",
                "A_Title Content2 Author2",
                "B_Title Content3 Author3"
                 };

        string expected = $"A_Title - Content2: Author2{Environment.NewLine}" +
                          $"B_Title - Content3: Author3{Environment.NewLine}" +
                          "C_Title - Content1: Author1";

        Article current = _article.AddArticles(articles);
        string result = _article.GetArticleList(current, "title");

        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        articles = new string[]
                 {
                "C_Title Content1 Author1",
                "A_Title Content2 Author2",
                "B_Title Content3 Author3"
                    };

        string expected = string.Empty;

        Article current = _article.AddArticles(articles);
        string result = _article.GetArticleList(current, "empty");

        Assert.That(result, Is.EqualTo(expected));
    }
}
