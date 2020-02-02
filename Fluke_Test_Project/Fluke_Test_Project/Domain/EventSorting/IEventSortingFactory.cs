using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fluke_Test_Project.Domain.EventSorting
{
    public interface IEventSortingFactory
    {
        IEventSorting EventSorting(string sortSelector);
    }

    public class EventSortingFactory : IEventSortingFactory
    {
        private IEnumerable<IEventSorting> _eventSortings;

        public EventSortingFactory(IEnumerable<IEventSorting> eventSortings)
        {
            _eventSortings = eventSortings;
        }

        public IEventSorting EventSorting(string sortSelector)
        {
            if(string.IsNullOrEmpty(sortSelector))
            {
                throw new ArgumentException($"{nameof(sortSelector)} cannot be either empty or null");
            }

            var sortSelected = _eventSortings
                .Where(es => string.Equals(es.SortSelector, sortSelector, StringComparison.InvariantCultureIgnoreCase));

            if(sortSelected.Count() > 1)
            {
                throw new AmbiguousMatchException("Cannot have multiple instances of same event sorting");
            }

            return sortSelected.First();
        }
    }
}
