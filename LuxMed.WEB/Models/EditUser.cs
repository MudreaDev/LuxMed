using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxMed.Domain.Entities.Enums;

namespace LuxMed.Models
{
    public class EditUser
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public URole Level { get; set; }
    }
}