using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Order
{
    public class OrderFilterDTO
    {
        public int? PageIndex { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? sortType { get; set; }
    }
}
