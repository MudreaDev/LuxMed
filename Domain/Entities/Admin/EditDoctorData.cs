using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.Domain.Entities.Admin
{
     public class EditDoctorData
     {
          public string Username { get; set; }

          public string Email { get; set; }

          public string Phone { get; set; }

          public string Type { get; set; }

          public string Description { get; set; }

          public string Image { get; set; }
     }
}
