using Fluke_Test_Project.Domain.Commands;
using Fluke_Test_Project.Domain.EventSorting;
using Fluke_Test_Project.Models;
using Fluke_Test_Project.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fluke_Test_Project.Domain.Handlers
{
    public class EventsRequestHandler : IRequestHandler<EventsRequest, IEnumerable<Event>>
    {
        private const int DefaultDays = 100;
        private readonly IEonetRepo _eonetRepo;
        private readonly IEventSortingFactory _eventSortingFactory;

        public EventsRequestHandler(
            IEonetRepo eonetRepo,
            IEventSortingFactory eventSortingFactory)
        {
            _eonetRepo = eonetRepo;
            _eventSortingFactory = eventSortingFactory;
        }

        public Task<IEnumerable<Event>> Handle(EventsRequest request, CancellationToken cancellationToken)
        {
            var days = request.Date.HasValue ? EvalDays(request.Date.Value) : DefaultDays;
            var enotRequestModel = new EonetRequestModel
            { 
                Days = days,
                Status = request.Status,
                Limit = request.Limit
            };
            var result = _eonetRepo.GetEvents(enotRequestModel);

            FilterEvents(result, request);

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                var eventSorting = _eventSortingFactory.EventSorting(request.SortBy);
                eventSorting.Sort(result);
            }

            return Task.FromResult(result);
        }

        private void FilterEvents(IEnumerable<Event> result, EventsRequest request)
        {
            if (request.CategoryId > 0)
            {
                result = result
                    .ToList()
                    .Where(evt => evt.Categories.Any(cat => cat.Id == request.CategoryId));
            }
        }

        private int EvalDays(DateTime date)
        {
            var currentDate = DateTime.Now.Date;
            return currentDate.Subtract(date).Days + 1;
        }
    }
}
