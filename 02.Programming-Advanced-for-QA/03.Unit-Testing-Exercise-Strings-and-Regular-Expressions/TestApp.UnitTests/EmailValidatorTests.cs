using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{

    [TestCase("prezhdarova@gmail.com")]
    [TestCase("prezhdarova34.rositsa@gmail.com")]
    [TestCase("prezhdarova34.rositsa@gmailco-d.c.om")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("prezhdarova@gmailcom")]
    [TestCase("prezhdarova34.rositsagmail.com")]
    [TestCase("@gmailco-d.c.om")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(result, Is.False);
    }
}
