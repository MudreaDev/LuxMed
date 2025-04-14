using LuxMed.Domain.Entities.Appointment;
using LuxMed.Domain.Entities.Doctor;
using LuxMed.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.BusinessLogic.AppBL
{
     public class TableContext : DbContext
     {
          public TableContext() : base("name=LuxMed")
          {
          }

          public virtual DbSet<UserTable> Users { get; set; }
          public virtual DbSet<Session> Session { get; set; }
          public virtual DbSet<DoctorTable> Doctors { get; set; }
          public virtual DbSet<AppointmentTable> Appointments { get; set; }
     }
}
