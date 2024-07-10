using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHabits.Database.Interfaces
{
    public interface ITenantService
    {
        public string GetConnectionString();
        public Tenant GetTenant();
    }
}
