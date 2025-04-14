﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.Domain.Entities.User
{
        public class ULoginData
        {
            public string Email { get; set; }

            public string Password { get; set; }

            public DateTime LoginDateTime { get; set; }

            public string LoginIp { get; set; }
        }
}
