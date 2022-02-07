using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Services
{
    internal interface IOrderServiceRepository
    {
        public void SaveOrder(Order order)
        {

        }
    }
}
