using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Startups.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStartupName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Startups",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Startups");
        }
    }
}
