using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;


namespace Demo_API_Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //build-in system.text.json nugget package Serialize (Object to Json)

            WeatherForecast forecast = new WeatherForecast();
            string weatherInfo = System.Text.Json.JsonSerializer.Serialize(forecast);
            Console.WriteLine(weatherInfo);

            //Deserialize (Json to C sharp Object

            string jsonString = File.ReadAllText("C:\\Users\\Admin\\Desktop\\Rosi\\Back-End-TestAutomation\\DemoData.json");
            WeatherForecast forecastFromJson = System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(jsonString);


            //newtonsoft json package - Serialize

            WeatherForecast forecastNS = new WeatherForecast();
            string weatherForecastNS = JsonConvert.SerializeObject(forecastNS, Formatting.Indented);        //using formatting  Formatting.Indented
            Console.WriteLine(weatherForecastNS);

            //newtonsoft Desirialized from text to C Sharp Object
            
            jsonString = File.ReadAllText("C:\\Users\\Admin\\Desktop\\Rosi\\Back-End-TestAutomation\\DemoData.json");
            WeatherForecast weatherInfoNS= JsonConvert.DeserializeObject<WeatherForecast>(jsonString);

            //working with anonymous Object
            var json = @"{'firstName': 'Rositsa',
                          'lastName': 'Prezhdarova',
                          'jobTitle': 'Project and Quality Manager' }";

            var template = new
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                JobTitle = string.Empty

            };

            var person = JsonConvert.DeserializeAnonymousType(json, template);


            //applying naming convention to the class properties
            WeatherForecast weatherForecastResolver = new WeatherForecast();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            string snakeCaseJson = JsonConvert.SerializeObject(weatherForecastResolver, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
            Console.WriteLine(snakeCaseJson);

            //Jobject

            var jsonASString = JObject.Parse(@"{'products': [
            {'name': 'Fruits', 'products': ['apple', 'banana']},
            {'name': 'Vegetables', 'products': ['cucumber']}]}");
            var products = jsonASString["products"].Select(t => string.Format("{0} ({1})", t["name"],
                string.Join(", ", t["products"])
                ));

            //RestSharp
            //Executing simple HTTP get request

            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/users/softuni/repos", Method.Get);

            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
          //  Console.WriteLine(response.Content);

            //Using URL Segment Parameters

            var clientSP = new RestClient("https://api.github.com");
            var requestURLSegments = new RestRequest("/repos/{user}/{repo}/issues/{id}", Method.Get);

            requestURLSegments.AddUrlSegment("user", "testnakov");
            requestURLSegments.AddUrlSegment("repo", "test-nakov-repo");
            requestURLSegments.AddUrlSegment("id", 1);

            var responseURLSegments = client.Execute(requestURLSegments);
            Console.WriteLine(responseURLSegments.StatusCode);
            Console.WriteLine(responseURLSegments.Content);


            //deserializing json response

            var requestDeserializing = new RestRequest("/users/softuni/repos", Method.Get);
            var responseDeserializing = client.Execute(requestDeserializing);  
            var repos = JsonConvert.DeserializeObject<List<Repo>>(responseDeserializing.Content);


            //http post with authentication

            var clientWithAuthentication = new RestClient(new RestClientOptions("https://api.github.com")
            {
                Authenticator = new HttpBasicAuthenticator("userName", "api-Token")
            });
            var postRequest = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Post);
            postRequest.AddHeader("Content-type", "application/json");
            postRequest.AddJsonBody(new { title = "SomeTitle", body = "SomeBody" });
            var responsePost = clientWithAuthentication.Execute(postRequest);
            Console.WriteLine(responsePost.StatusCode);
            Console.WriteLine(responsePost.Content);

        }
    }
}
