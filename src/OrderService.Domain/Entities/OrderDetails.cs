using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class OrderDetails
    {
        public Guid OrderId { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
        public IEnumerable<OrderLineItem> OrderLineItems { get; set; }
    }
}
