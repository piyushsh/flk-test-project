using System;
using System.Threading.Tasks;
using Fluke_Test_Project.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fluke_Test_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IMediator _mediator;

        public EventsController(
            ILogger<EventsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] int categoryId,
            [FromQuery] string status,
            [FromQuery] int limit,
            [FromQuery] string date,
            [FromQuery] string sortBy)
        {
            DateTime.TryParse(date, out var dateTime);
            var request = new EventsRequest {
                CategoryId = categoryId,
                Status = status,
                Limit = limit,
                Date = dateTime,
                SortBy = sortBy
            };

            var result = await _mediator.Send(request);

            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{eventId}")]
        public async Task<IActionResult> Get(string eventId)
        {
            var request = new EventRequest
            {
                EventId = eventId
            };

            var result = await _mediator.Send(request);

            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
    }
}
