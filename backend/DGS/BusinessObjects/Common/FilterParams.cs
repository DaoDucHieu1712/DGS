using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.Common
{
    public class FilterParams
    {
        public virtual int? PageIndex { get; set; }
        public virtual string? SortType { get; set; }
    }
}
