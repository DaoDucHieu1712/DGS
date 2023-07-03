using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Product
{
    public class ProductFilterDTO
    {
        public int? pageIndex { get; set; }
        public string? Name { get; set; }
        public decimal? ToPrice { get; set; }
        public decimal? FromPrice { get; set; }
        public int ? CategoryId { get; set; }
        public string? sortType { get; set; }
    }
}
