﻿
namespace OrderService.Domain.Models.Entities
{
    public class OrderLineItem
    {
        public Guid OrderId { get; set; }
        public Guid MenuLineItemId { get; set; }
        public int Quantity { get; set; }
    }
}
