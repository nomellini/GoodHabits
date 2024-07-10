using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHabits.Database
{
    public class TenantSettings
    {
        public string? DefaultConnectionString { get; set; }
        public List<Tenant>? Tenants { get; set; }
    }
}
