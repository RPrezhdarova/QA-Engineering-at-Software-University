using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingBasics
{
    internal class GlobalConstants
    {
        public const string BaseUrl = "http://localhost:5000/api";

        public static string AuthenticateUser(string email, string password)
        {
            var restClient = new RestClient(BaseUrl);
            var request = new RestRequest("user/admin-login", Method.Post);
            request.AddJsonBody(new { email, password });

            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Assert.Fail($"Authentication failed with status code: {response.StatusCode}, " +
                            $"content: {response.Content}");
            }

            var content = JObject.Parse(response.Content);
            return content["token"]?.ToString();
        }
        public static void UserWait()
        {
            Thread.Sleep(100);
        }
    }    
}
