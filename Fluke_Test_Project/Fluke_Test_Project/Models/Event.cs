using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Fluke_Test_Project.Models
{
    public class Event
    {
        public string Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Source> Sources { get; set; }
        public IEnumerable<GeoData> Geometries { get; set; }
        public DateTime? Closed { get; set; }

        [JsonConstructor]
        public Event(string id)
        {
            Id = id;
        }
    }
}
