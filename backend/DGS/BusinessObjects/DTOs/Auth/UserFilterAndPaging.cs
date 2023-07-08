using DGS.BusinessObjects.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Auth
{
    public class UserFilterAndPagingDTO

    {
        public List<UserDTO>? Users { get; set; }
        public int? Total { get; set; }
        public int? PageIndex { get; set; }
    }
}
