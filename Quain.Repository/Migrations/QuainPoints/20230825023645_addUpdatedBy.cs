using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quain.Repository.Migrations.QuainPoints
{
    /// <inheritdoc />
    public partial class addUpdatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PointsChanges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PointsChanges");
        }
    }
}
