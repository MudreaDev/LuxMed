﻿using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Entities.Appointment;
using LuxMed.Domain.Entities.Doctor;
using LuxMed.Domain.Entities.User;
using project_CAN.BusinessLogic.Core;
using System.Collections.Generic;
using System.Web;

namespace project_CAN.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public BoolResp UserLoginSessionBL(ULoginData data)
        {
            return UserLoginAction(data);
        }

        public BoolResp UserRegistrationSessionBL(URegisterData data)
        {
            return UserRegisterAction(data);
        }

        public BoolResp AddAppointment(AddAppointmentData data)
        {
            return AddAppointmentAction(data);
        }

        public List<UserTable> GetUserList()
        {
            return GetUserListAction();
        }

        public List<DoctorTable> GetDoctorList()
        {
            return GetDoctorListAction();
        }

        public List<AppointmentTable> GetAppointmentList()
        {
            return GetAppointmentListAction();
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}