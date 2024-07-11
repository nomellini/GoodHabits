using GoodHabits.Database.Entities;
using GoodHabits.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoodHabits.Database
{
    public class GoodHabitsDbContext : DbContext
    {

        private readonly ITenantService _tenantService;

        public GoodHabitsDbContext(DbContextOptions options,
            ITenantService service) : base(options) 
        { 
            _tenantService = service; 
        }

        public string TenantName
        {
            get => _tenantService.GetTenant()?.TenantName ?? String.Empty;
        }

        public DbSet<Habit>? Habits { get; set; }

        public DbSet<Todo>? Todos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = _tenantService.GetConnectionString();
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                optionsBuilder.UseNpgsql(_tenantService.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = modelBuilder.Model.GetEntityTypes()
                    .Where(t => typeof(IHasTenant).IsAssignableFrom(t.ClrType));

            foreach (var entityType in entityTypes)
            {
                var method = typeof(GoodHabitsDbContext)? 
                    .GetMethod(nameof(SetGlobalQueryFilter), BindingFlags.NonPublic | BindingFlags.Instance)?
                    .MakeGenericMethod(entityType.ClrType);

                method?.Invoke(this, new object[] { modelBuilder });
            }

            //    modelBuilder.Entity<Habit>().HasQueryFilter(a => a.TenantName == TenantName);

            SeedData.Seed(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.Entries<IHasTenant>()
                .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified)
                .ToList()
                .ForEach(entry => entry.Entity.TenantName = TenantName);
            return await base.SaveChangesAsync(cancellationToken);

        }

        private void SetGlobalQueryFilter<T>(ModelBuilder modelBuilder) where T : BaseHasTenantEntity
        {
            modelBuilder.Entity<T>().HasQueryFilter(e => e.TenantName == TenantName);
        }



        //static readonly MethodInfo SetGlobalQueryMethod = typeof(GoodHabitsDbContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
        //                                                        .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        //public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseHasTenantEntity
        //{
        //    builder.Entity<T>().HasKey(e => e.Id);
        //    builder.Entity<T>().HasQueryFilter(e => e.TenantName == TenantName );
        //}

    }
}
