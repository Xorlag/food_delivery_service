using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class OrderLineItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
