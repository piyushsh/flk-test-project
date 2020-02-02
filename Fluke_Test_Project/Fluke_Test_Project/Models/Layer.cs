using System.Collections.Generic;

namespace Fluke_Test_Project.Models
{
    public class Layer
    {
        public string Name { get; set; }
        public string ServiceUrl { get; set; }
        public string ServiceTypeId { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }
    }
}