﻿using LuxMed.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxMed.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
        base("name = LuxMed") //conection string name define in your web.config
        {

        }

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
