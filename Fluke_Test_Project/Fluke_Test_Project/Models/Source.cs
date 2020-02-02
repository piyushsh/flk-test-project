using Newtonsoft.Json;

namespace Fluke_Test_Project.Models
{
    public class Source
    {
        public string Id { get; }
        public string Title { get; set; }
        [JsonProperty("source")]
        public string SourceUrl { get; set; }
        public string Link { get; set; }

        [JsonConstructor]
        public Source(string id)
        {
            Id = id;
        }
    }
}