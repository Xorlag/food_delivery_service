﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Messages
{
    public class AcceptTicketCommand
    {
        public Guid OrderId { get; set; }
    }
}
