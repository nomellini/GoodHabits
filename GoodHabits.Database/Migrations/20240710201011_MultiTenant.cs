using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodHabits.Database.Migrations
{
    /// <inheritdoc />
    public partial class MultiTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TenantName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Habits",
                columns: new[] { "Id", "Description", "Name", "TenantName" },
                values: new object[,]
                {
                    { new Guid("2b4a30af-cd49-4359-9738-7b552609e6d1"), "Become a francophone", "Learn French", "CloudSphere" },
                    { new Guid("4a4399ab-729d-4b08-ba87-7a4e9b179376"), "Become a SaaSer", "Learn Saad", "CloudSphere" },
                    { new Guid("d94df76f-a3cd-4501-919c-b09cc3420f37"), "Bluewave - Become a francophone", "Bluewave - Learn French", "Bluewave" },
                    { new Guid("e2aa93c9-b426-4db9-888f-ced925803e1a"), "Become a master", "Learn Multi Tenancy", "CloudSphere" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habits");
        }
    }
}
