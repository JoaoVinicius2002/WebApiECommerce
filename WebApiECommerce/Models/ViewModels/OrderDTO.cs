using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiECommerce.Models.ViewModels
{
    public class OrderDTO
    {
        public int OrderId { get; internal set; }
        public string Address { get; internal set; }
        public List<Product> Products { get; internal set; }
        public int TeamId { get; internal set; }
        public Team Team { get; internal set; }
        public DateTime WhenCreated { get; internal set; }
        public DateTime WhenDelivered { get; internal set; }
        public decimal Price { get; internal set; }
        public IEnumerable<OrderProduct> OrderProducts { get; internal set; }
    }
}
