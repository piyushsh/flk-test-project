using Fluke_Test_Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fluke_Test_Project.Domain.EventSorting
{
    public class DateEventSorting : IEventSorting
    {
        public string SortSelector => EventSortingType.Date.ToString();

        public void Sort(IEnumerable<Event> events)
        {
            events.OrderByDescending(@event => @event.Closed.Value);
        }
    }
}
