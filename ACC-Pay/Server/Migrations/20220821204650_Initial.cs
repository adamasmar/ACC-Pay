using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACC_Pay.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurity = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "W4Years",
                columns: table => new
                {
                    W4YearsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_W4Years", x => x.W4YearsId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContactInformation",
                columns: table => new
                {
                    EmployeeContactInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryPhoneNumber = table.Column<int>(type: "int", nullable: true),
                    SecondaryPhoneNumber = table.Column<int>(type: "int", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContactInformation", x => x.EmployeeContactInformationId);
                    table.ForeignKey(
                        name: "FK_EmployeeContactInformation_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeW4Configuration",
                columns: table => new
                {
                    EmployeeW4ConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeContactInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value2c = table.Column<bool>(type: "bit", nullable: false),
                    Value3 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Value4a = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Value4b = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Value4c = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DateSigned = table.Column<DateTime>(type: "date", nullable: false),
                    W4YearsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeW4Configuration", x => x.EmployeeW4ConfigurationId);
                    table.ForeignKey(
                        name: "FK_EmployeeW4Configuration_EmployeeContactInformation_EmployeeContactInformationId",
                        column: x => x.EmployeeContactInformationId,
                        principalTable: "EmployeeContactInformation",
                        principalColumn: "EmployeeContactInformationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeW4Configuration_W4Years_W4YearsId",
                        column: x => x.W4YearsId,
                        principalTable: "W4Years",
                        principalColumn: "W4YearsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContactInformation_EmployeeId",
                table: "EmployeeContactInformation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeW4Configuration_EmployeeContactInformationId",
                table: "EmployeeW4Configuration",
                column: "EmployeeContactInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeW4Configuration_W4YearsId",
                table: "EmployeeW4Configuration",
                column: "W4YearsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeW4Configuration");

            migrationBuilder.DropTable(
                name: "EmployeeContactInformation");

            migrationBuilder.DropTable(
                name: "W4Years");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
