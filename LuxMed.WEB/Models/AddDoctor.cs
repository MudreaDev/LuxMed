﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxMed.Models
{
    public class AddDoctor
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}