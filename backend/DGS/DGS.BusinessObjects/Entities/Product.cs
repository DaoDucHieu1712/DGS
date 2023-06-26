using DGS.BusinessObjects.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.Entities
{
    [Table("Product")]
    public class Product : BaseEntity<int>
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
