using LuxMed.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxMed.Models
{
     public class AddUser
     {
          public string Username { get; set; }

          public string Password { get; set; }

          public string Email { get; set; }

          public URole Level { get; set; }
     }
}