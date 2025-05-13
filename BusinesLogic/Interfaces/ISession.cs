using LuxMed.Domain.Entities.Appointment;
using LuxMed.Domain.Entities.Doctor;
using LuxMed.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LuxMed.BusinessLogic.Interfaces
{
    public interface ISession
    {
        BoolResp UserLoginSessionBL(ULoginData data);
        BoolResp UserRegistrationSessionBL(URegisterData data);
        BoolResp AddAppointment(AddAppointmentData data);
        List<UserTable> GetUserList();
        List<DoctorTable> GetDoctorList();
        List<AppointmentTable> GetAppointmentList();
        HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string apiCookieValue);


    }
}
