﻿using GoodHabits.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHabits.Database.Entities
{
    public class Habit : BaseHasTenantEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        
    }
}
