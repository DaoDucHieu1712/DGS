﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Auth
{
    public class UserClientDTO
    {
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public string AccessToken { get; set; }
    }
}
