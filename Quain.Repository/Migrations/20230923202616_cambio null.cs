using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quain.Repository.Migrations
{
    /// <inheritdoc />
    public partial class cambionull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointsChanges");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.AlterDatabase(
                oldCollation: "Modern_Spanish_CI_AI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "Modern_Spanish_CI_AI");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CUIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.PointsId);
                    table.ForeignKey(
                        name: "FK_Points_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointsChanges",
                columns: table => new
                {
                    PointsChangesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BillNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsChanges", x => x.PointsChangesId);
                    table.ForeignKey(
                        name: "FK_PointsChanges_Points_PointsId",
                        column: x => x.PointsId,
                        principalTable: "Points",
                        principalColumn: "PointsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_CustomerId",
                table: "Points",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PointsChanges_PointsId",
                table: "PointsChanges",
                column: "PointsId");
        }
    }
}
