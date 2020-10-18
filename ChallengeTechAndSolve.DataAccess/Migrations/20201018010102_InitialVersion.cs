using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeTechAndSolve.DataAccess.Migrations
{
    public partial class InitialVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Traceability",
                columns: table => new
                {
                    TraceabilityId = table.Column<Guid>(nullable: false),
                    Document = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traceability", x => x.TraceabilityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Traceability");
        }
    }
}
