using DGS.BusinessObjects.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Order
{
    public class OrderFilterAndPagingDTO
    {
        public List<OrderDTO>? Orders { get; set; }
        public int? Total { get; set; }
        public int? PageIndex { get; set; }
    }
}
