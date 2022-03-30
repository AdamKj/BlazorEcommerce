using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.DTO
{
    public class OrderOverviewResponseDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string Product { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
