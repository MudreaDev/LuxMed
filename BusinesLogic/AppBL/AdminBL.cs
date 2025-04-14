using LuxMed.BusinessLogic.Core;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Entities.Admin;
using LuxMed.Domain.Entities.User;
using project_CAN.BusinessLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.BusinessLogic.AppBL
{
    public class AdminBL : AdminApi, IAdmin
    {
        public BoolResp AddUser(AddUserData data)
        {
            return AddUserAction(data);
        }

        public BoolResp AddDoctor(AddDoctorData data)
        {
            return AddDoctorAction(data);
        }

        public BoolResp EditUser(EditUserData data)
        {
            return EditUserAction(data);
        }

        public BoolResp EditDoctor(EditDoctorData data)
        {
            return EditDoctorAction(data);
        }

        public BoolResp EditAppointment(EditAppointmentData data)
        {
            return EditAppointmentAction(data);
        }

        public void DeleteUser(int id)
        {
            DeleteUserAction(id);
        }

        public void DeleteDoctor(int id)
        {
            DeleteDoctorAction(id);
        }

        public void DeleteAppointment(int id)
        {
            DeleteAppointmentAction(id);
        }
    }
}
