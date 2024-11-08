using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoNunitTest.Models
{
    public class Place
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }

        public string Name { get; set; }

        public string StateAbbreviation { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
