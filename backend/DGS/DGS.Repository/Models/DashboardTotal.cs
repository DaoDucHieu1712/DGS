using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository.Models
{
    public class DashboardTotal
    {
        public int Users {get; set;}
        public int Products { get; set; }
        public int Orders { get; set; }
        public int Categories { get; set; }
    }
}
