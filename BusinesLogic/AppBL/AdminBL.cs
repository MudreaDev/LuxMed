using LuxMed.BusinessLogic.Core;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Entities.Admin;
using LuxMed.Domain.Entities.User;

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
