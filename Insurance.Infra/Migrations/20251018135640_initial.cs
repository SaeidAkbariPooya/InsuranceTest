using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Insurance.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceCoverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MinCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCoverages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestCoverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceRequestId = table.Column<int>(type: "int", nullable: false),
                    CoverageId = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestCoverages_InsuranceCoverages_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "InsuranceCoverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestCoverages_InsuranceRequests_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InsuranceCoverages",
                columns: new[] { "Id", "MaxCapital", "MinCapital", "Rate", "Title" },
                values: new object[,]
                {
                    { 1, 500000000m, 5000m, 0.00520m, "پوشش جراحی" },
                    { 2, 400000000m, 4000m, 0.00420m, "پوشش دندانپزشکی" },
                    { 3, 200000000m, 2000m, 0.00400m, "پوشش بستری" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestCoverages_CoverageId",
                table: "RequestCoverages",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCoverages_InsuranceRequestId",
                table: "RequestCoverages",
                column: "InsuranceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestCoverages");

            migrationBuilder.DropTable(
                name: "InsuranceCoverages");

            migrationBuilder.DropTable(
                name: "InsuranceRequests");
        }
    }
}
