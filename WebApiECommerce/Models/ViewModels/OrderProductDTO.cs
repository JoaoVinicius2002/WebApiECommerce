using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiECommerce.Models.ViewModels
{
    public class OrderProductDTO
    {
        public Order Order { get; internal set; }
        public int OrderId { get; internal set; }
        public int ProductId { get; internal set; }
        public string OrderAddress { get; internal set; }
        public DateTime OrderWhenCreated { get; internal set; }
        public DateTime OrderWhenDelivered { get; internal set; }
        public List<Product> Products { get; internal set; }
        public decimal TotalPrice { get; internal set; }
        public int TeamId { get; internal set; }
        public Team Team { get; internal set; }
    }
}
