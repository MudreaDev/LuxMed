﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.BusinessLogic;

namespace LuxMed.BusinesLogic
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