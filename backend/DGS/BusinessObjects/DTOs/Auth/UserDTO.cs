﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Auth
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string ImageURL { get; set; }
    }
}
