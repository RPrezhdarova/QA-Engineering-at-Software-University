using NUnit.Framework;
namespace TestApp.UnitTests;
public class EmailTests
{
    // TODO: finish test
    [Test]
    public void Test_IsValidEmail_ValidEmail()
    {
        // Arrange
        string validEmail = "test@example.com";

        // Act
        bool actualResult= Email.IsValidEmail( validEmail);
        // Assert
    
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Test_IsValidEmail_InvalidEmail()
    {
        // Arrange
        string validEmail = "test";

        // Act
        bool actualResult = Email.IsValidEmail(validEmail);
        // Assert
       
        Assert.That(actualResult, Is.False);
    }

    [Test]
    public void Test_IsValidEmail_NullInput()
    {
        // Arrange
        string validEmail = "";

        // Act
        bool actualResult = Email.IsValidEmail(validEmail);
        // Assert

        Assert.That(actualResult, Is.False);
    }
}
