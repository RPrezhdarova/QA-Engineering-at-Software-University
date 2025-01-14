using DemoNunitTest.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNunitTest
{
    public class ZippopotamusTests
    {
        [Test]
        [TestCase ("BG", "1000", "София / Sofija")]
        [TestCase ("BG", "5000", "Велико Търново / Veliko Turnovo")]
        [TestCase ("CA", "M5S", "Downtown Toronto (University of Toronto / Harbord)")]
        [TestCase ("GB", "B1", "Birmingham")]
        [TestCase ("DE", "01067", "Dresden")]
        public void DataDrivenTests(string countryCode, string zipCode, string expectedPlace)
        {
            //Arrange
            var client = new RestClient("https://api.zippopotam.us/");
            var request = new RestRequest(countryCode + "/" + zipCode, Method.Get);

            //Act
            var response = client.Execute(request);
            var location = JsonConvert.DeserializeObject<Location>(response.Content);

            //Assert
            Assert.That(location.Places[0].PlaceName, Is.EqualTo(expectedPlace));

        }
    }
}
