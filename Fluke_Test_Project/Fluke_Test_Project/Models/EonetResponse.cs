using System.Collections.Generic;

namespace Fluke_Test_Project.Models
{
    public class EonetResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public IEnumerable<Event> Events {get; set; }
    }
}
