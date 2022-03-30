using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.DTO
{
    public class OrderDetailsResponseDTO
    {
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderDetailsProductResponseDTO> Products { get; set; }
    }
}
