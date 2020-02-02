using Fluke_Test_Project.Models;
using System.Collections.Generic;

namespace Fluke_Test_Project.Domain.EventSorting
{
    public interface IEventSorting
    {
        void Sort(IEnumerable<Event> events);

        string SortSelector { get; }
    }
}
