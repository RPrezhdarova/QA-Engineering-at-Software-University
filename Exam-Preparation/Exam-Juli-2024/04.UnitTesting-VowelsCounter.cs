using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TestApp.Tests
{
    public class VowelsCounterTests
    {
        [Test]
        public void Test_CountTotalVowels_GetEmptyList_ReturnsZero()
        {
            // Arrange
            List<string> words = new List<string>();
            int expectedResult = 0;

            //Act
            int actualResult= VowelsCounter.CountTotalVowels(words);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_CountTotalVowels_GetListWithEmptyStringValues_ReturnsZero()
        {
            // Arrange
            List<string> words = new List<string>() { "", "" };
            int expectedResult = 0;

            //Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_CountTotalVowels_MultipleLowerCaseStrings_ReturnsVowelsCount()
        {
            // Arrange
            List<string> words = new List<string>() { "prezhdarova", "rositsa" };
            int expectedResult = 7;

            //Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_CountTotalVowels_GetStringsWithNoVowels_ReturnsZero()
        {
            // Arrange
            List<string> words = new List<string>() { "przhdrv", "rsts" };
            int expectedResult = 0;

            //Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_CountTotalVowels_StringsWithMixedCaseVowels_ReturnsVowelsCount()
        {
            // Arrange
            List<string> words = new List<string>() { "PrezhdarovA", "RositsA" };
            int expectedResult = 7;

            //Act
            int actualResult = VowelsCounter.CountTotalVowels(words);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}
