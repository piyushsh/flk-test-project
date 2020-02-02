using Fluke_Test_Project.Domain.Commands;
using Fluke_Test_Project.Models;
using Fluke_Test_Project.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fluke_Test_Project.Domain.Handlers
{
    public class EventRequestHandler : IRequestHandler<EventRequest, Event>
    {
        private IEonetRepo _eonetRepo;

        public EventRequestHandler(IEonetRepo eonetRepo)
        {
            _eonetRepo = eonetRepo;
        }

        public Task<Event> Handle(EventRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_eonetRepo.GetEvent(request.EventId));
        }
    }
}
