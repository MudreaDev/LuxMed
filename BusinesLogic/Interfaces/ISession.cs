﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.WEB.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ActionStatus UserLogin(ULoginData data);
        LevelStatus CheckLevel(string key);
    }
}