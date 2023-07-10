using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quain.Repository.Migrations
{
    /// <inheritdoc />
    public partial class changingdnitocuit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "CUIT",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CUIT",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "DNI",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
