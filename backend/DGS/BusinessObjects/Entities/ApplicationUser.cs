using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() {
            Orders = new HashSet<Order>();
        }

        [Key]
        override public string Id { get; set; }
        public string DisplayName { get; set; }
        public bool Gender { get; set; }    
        public DateTime BirthDay { get; set; }
        public string ImageURL { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
