using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Messages
{
    public class TicketAcceptedEvent
    {
        public Guid OrderId { get; set; }
    }
}
