﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHabits.Database.Interfaces
{
    public interface IHasTenant
    {
        public string TenantName { get; set; }
    }
}