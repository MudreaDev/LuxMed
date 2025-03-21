using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxMed.WEB.Domain.Entities.User;
using LuxMed.WEB.Domain.Entities.Res;
using LuxMed.WEB.Domain.Entities.User.Global;
using LuxMed.WEB.Domain.Entities.Product;
namespace BusinesLogic.Core
{
       public class UserApi
        {
            internal ActionStatus UserLogData(ULoginData data)
            {
                return new ActionStatus();
            }

            internal LevelStatus CheckLevelLogic(string keySession)
            {
                return new LevelStatus();
            }

            internal ProductDetail GetProdUser(int id)
            {
                return new ProductDetail();
            }
        }
}

