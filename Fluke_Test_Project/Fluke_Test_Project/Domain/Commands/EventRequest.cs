using Fluke_Test_Project.Models;
using MediatR;

namespace Fluke_Test_Project.Domain.Commands
{
    public class EventRequest : IRequest<Event>
    {
        public string EventId { get; set; }
    }
}
