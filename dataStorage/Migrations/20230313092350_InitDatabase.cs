using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataStorage.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrandStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrandStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerPhoneNr = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNr = table.Column<int>(type: "int", nullable: false),
                    CustomerPhoneNrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_PhoneNumber_CustomerPhoneNrId",
                        column: x => x.CustomerPhoneNrId,
                        principalTable: "PhoneNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Errands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrandTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeEmployeeComment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrandStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Errands_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Errands_ErrandStatus_ErrandStatusId",
                        column: x => x.ErrandStatusId,
                        principalTable: "ErrandStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Errands_PhoneNumber_PhoneNrId",
                        column: x => x.PhoneNrId,
                        principalTable: "PhoneNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerPhoneNrId",
                table: "Customers",
                column: "CustomerPhoneNrId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Errands_CustomerId",
                table: "Errands",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_ErrandStatusId",
                table: "Errands",
                column: "ErrandStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_PhoneNrId",
                table: "Errands",
                column: "PhoneNrId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errands");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ErrandStatus");

            migrationBuilder.DropTable(
                name: "PhoneNumber");
        }
    }
}
