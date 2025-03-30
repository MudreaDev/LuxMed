using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxMed.Domain.Entities.Res;
using LuxMed.Domain.Entities.User.Global;
using LuxMed.Domain.Entities.User;

namespace LuxMed.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ActionStatus UserLogin(ULoginData data);
        LevelStatus CheckLevel(string key);
    }
}