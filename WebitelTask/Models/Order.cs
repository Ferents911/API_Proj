using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebitelAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Amount { get; set; }

        public OrderProduct OrderProduct { get; set; }
    }
}
