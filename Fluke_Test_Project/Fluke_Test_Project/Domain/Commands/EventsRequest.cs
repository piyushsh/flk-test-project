using Fluke_Test_Project.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Fluke_Test_Project.Domain.Commands
{
    public class EventsRequest : IRequest<IEnumerable<Event>>
    {
        public int CategoryId { get; set; }
        public string Status { get; set; } 
        public int Limit { get; set; } 
        public DateTime? Date { get; set; }
        public string SortBy { get; set; }
    }
}
