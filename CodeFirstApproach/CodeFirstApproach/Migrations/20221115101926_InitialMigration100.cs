using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApproach.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_name",
                table: "Random",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_name",
                table: "Random");
        }
    }
}
