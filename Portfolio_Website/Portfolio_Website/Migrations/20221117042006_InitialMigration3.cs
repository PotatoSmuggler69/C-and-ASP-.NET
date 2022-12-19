using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebsite.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOA",
                table: "Contact",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOA",
                table: "Contact");
        }
    }
}
