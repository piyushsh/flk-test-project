using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Fluke_Test_Project.Models
{
    public class GeoData
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public JArray Coordinates { get; set; }
    }
}