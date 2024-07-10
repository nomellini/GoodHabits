using GoodHabits.Database;
using GoodHabits.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GoodHabits.HabitsService
{
    public class TenantService : ITenantService
    {
        private HttpContext? _httpContext { get; }
        private readonly TenantSettings? _tenantSettings;
        private Tenant? _tenant;

        public TenantService(IOptions<TenantSettings>? tenantSettings, IHttpContextAccessor? contextAccessor)
        {

            _tenantSettings = tenantSettings?.Value;
            _httpContext = contextAccessor?.HttpContext;

            if (_httpContext != null)
            {
                if (_httpContext.Request.Headers.TryGetValue("tenant", out var tenantId))
                {
                    SetTenant(tenantId);
                }
                else
                {
                    throw new Exception("Invalid Tenant!");
                }
            }

        }

        private void SetTenant(string? tenantId)
        {
            _tenant = _tenantSettings?.Tenants?.Where(a => a.TenantName == tenantId).FirstOrDefault();
            if (_tenant == null)
                throw new Exception("Tenant Not found!");
            if (string.IsNullOrEmpty(_tenant.ConnectionString))
                setDefaultConnectionStringToCurrentTenant();
        }

        private void setDefaultConnectionStringToCurrentTenant()
        {
            if (_tenant != null)
                _tenant.ConnectionString = _tenantSettings?.DefaultConnectionString;
        }

        public string GetConnectionString() => _tenant?.ConnectionString!;
        public Tenant GetTenant() => _tenant!;
    }
}
