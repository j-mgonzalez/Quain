using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quain.Repository.Migrations
{
    /// <inheritdoc />
    public partial class changecodclientcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COD_CLIENT",
                table: "Customers",
                newName: "CodClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodClient",
                table: "Customers",
                newName: "COD_CLIENT");
        }
    }
}
