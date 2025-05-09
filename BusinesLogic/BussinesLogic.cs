using LuxMed.BusinessLogic.AppBL;
using LuxMed.BusinessLogic;
using LuxMed.BusinessLogic.Interfaces;
using project_CAN.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.BusinessLogic
{
    public class BussinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
        public IAdmin GetAdminBL()
        {
            return new AdminBL();
        }
       
    }
}
