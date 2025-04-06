using LuxMed.BusinessLogic.Core;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Enums;
using LuxMed.Domain.Entities.Res;
using LuxMed.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using LuxMed.Domain.Entities.User.Global;

namespace LuxMed.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public ActionStatus UserLogin(ULoginData data)
        {
            return UserLogData(data);
        }

        private ActionStatus UserLogData(ULoginData data)
        {
            throw new NotImplementedException();
        }

        public LevelStatus CheckLevel(string key)
        {
            return CheckLevelLogic(key);
        }

        private LevelStatus CheckLevelLogic(string key)
        {
            throw new NotImplementedException();
        }
    }
}
