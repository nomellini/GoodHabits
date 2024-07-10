using GoodHabits.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHabits.Database
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habit>().HasData(
                new Habit { Id = new Guid("d94df76f-a3cd-4501-919c-b09cc3420f37"), Name = "Bluewave - Learn French", Description = "Bluewave - Become a francophone", TenantName = "Bluewave" },
                new Habit { Id = new Guid("2b4a30af-cd49-4359-9738-7b552609e6d1"), Name = "Learn French", Description = "Become a francophone", TenantName = "CloudSphere" },
                new Habit { Id = new Guid("4a4399ab-729d-4b08-ba87-7a4e9b179376"), Name = "Learn Saad", Description = "Become a SaaSer", TenantName = "CloudSphere" },
                new Habit { Id = new Guid("e2aa93c9-b426-4db9-888f-ced925803e1a"), Name = "Learn Multi Tenancy", Description = "Become a master", TenantName = "CloudSphere" }
            );
        }
    }
}
