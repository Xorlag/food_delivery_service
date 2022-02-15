using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Domain.Entities
{
    public class Menu
    {
        public Guid MenuId { get; set; }
        public string Title { get; set; }
    }
}
