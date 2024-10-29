using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string text = "";
        List<string> expected = new List<string>();

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string text = "noUrls";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        // Arrange
        string text = "https://www.softuni.bg";
        List<string> expected = new List<string>() { "https://www.softuni.bg" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string text = "https://www.softuni.bg https://www.mybits.de";
        List<string> expected = new List<string>() { "https://www.softuni.bg", "https://www.mybits.de" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string text = "This is sample text with URLs: \"https://www.sof?tuni.bg\"";
        List<string> expected = new List<string>() { "https://www.sof?tuni.bg" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
