using GoodHabits.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHabits.Database.Entities
{
    public class BaseHasTenantEntity: BaseEntity, IHasTenant
    {
        public string TenantName { get; set; } = default!;
    }
}
