using Newtonsoft.Json;

namespace Fluke_Test_Project.Models
{
    public class Category
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public Layer Layers { get; set; }

        [JsonConstructor]
        public Category(int id)
        {
            Id = id;
        }
    }
}