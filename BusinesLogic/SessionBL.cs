using LuxMed.WEB.BusinessLogic.Interfaces;
using LuxMed.WEB.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.WEB.BusinesLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

        public IProduct GetProductBL()
        {
            return new ProductBL();
        }
    }
}
