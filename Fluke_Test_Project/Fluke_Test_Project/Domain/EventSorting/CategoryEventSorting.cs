using Fluke_Test_Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fluke_Test_Project.Domain.EventSorting
{
    public class CategoryEventSorting : IEventSorting
    {
        public string SortSelector => EventSortingType.Category.ToString();

        public void Sort(IEnumerable<Event> events)
        {
            events.OrderByDescending(@event => @event.Categories.Count());
        }
    }
}
