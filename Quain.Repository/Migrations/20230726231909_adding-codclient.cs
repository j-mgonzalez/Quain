using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quain.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addingcodclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "COD_CLIENT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "COD_CLIENT",
                table: "Customers",
                newName: "FirstName");
        }
    }
}
