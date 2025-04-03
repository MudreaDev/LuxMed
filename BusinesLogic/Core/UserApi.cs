using LuxMed.BusinessLogic.DBModel;
using LuxMed.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.BusinessLogic.Core
{
    public class UserApi
    {
        public bool UserSessionStatus()
        {
            return true;
        }

        internal ULoginResp UserSessionData(ULoginData data)
        {
            UDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == data.Username && u.Password ==
                data.Password);
            }
            if (result == null)
            {
                return new ULoginResp
                {
                    Status = false,
                    StatusMsg = "The username or password is incorrect"
                };
            }
            return new ULoginResp { Status = true };
        }

        internal class ULoginResp
        {
            internal string StatusMsg;

            public bool Status { get; internal set; }
        }
    }
}
