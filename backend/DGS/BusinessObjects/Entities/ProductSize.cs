using DGS.BusinessObjects.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.Entities
{
    [Table("ProductSize")]
    public class ProductSize : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int UnitInStock { get; set;}

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set;}
        [ForeignKey("SizeId")]
        public virtual Size Size { get; set;}
    }
}
