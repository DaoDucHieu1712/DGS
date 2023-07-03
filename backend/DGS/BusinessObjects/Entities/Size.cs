using DGS.BusinessObjects.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.Entities
{
    [Table("Size")]
    public class Size : BaseEntity<int>
    {
        public Size()
        {
            ProductSizes = new HashSet<ProductSize>();
        }
        public string SizeName { get; set; }
        public virtual ICollection<ProductSize>  ProductSizes { get; set; }
    }
}
