using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.Common
{
    public class EntityFilter<T>
    {
        public List<T>? list { get; set; }
        public int? total { get; set; }
        public int? pageIndex { get;set; }
    }
}
