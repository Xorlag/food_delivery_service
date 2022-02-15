using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public enum OrderStatus
    {
        ApprovalPending,
        Approved,
        Rejected,
        PreparingPending,
        Preparing,
        CancelledPending,
        Cancelled,
        DeliveryPending,
        DeliveryInProgress,
        Delivered
    }
}
