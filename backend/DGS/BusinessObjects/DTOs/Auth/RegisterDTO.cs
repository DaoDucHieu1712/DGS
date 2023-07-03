using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string ImageURL { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}

