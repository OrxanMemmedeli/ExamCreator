using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class CompanyAllTableHeadAndAddedDebtAndPaymantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booklets_Companies_CompanyId",
                table: "Booklets");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_CreatUserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_ModifyUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ModifyUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Booklets_CompanyId",
                table: "Booklets");

            migrationBuilder.DropColumn(
                name: "CreatUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Booklets");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DailyAmount",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DebtLimit",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsPenal",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PersentOfFine",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => new { x.CompanyId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_CompanyUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsensionalDebt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsensionalDebtDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PenalDebt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PenalDebtDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amout = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_AppUserId",
                table: "CompanyUsers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_CompanyId",
                table: "Debts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CompanyId",
                table: "Payments",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropColumn(
                name: "DailyAmount",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DebtLimit",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsPenal",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PersentOfFine",
                table: "Companies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatUserId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifyUserId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Booklets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatUserId",
                table: "Companies",
                column: "CreatUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ModifyUserId",
                table: "Companies",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booklets_CompanyId",
                table: "Booklets",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booklets_Companies_CompanyId",
                table: "Booklets",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_CreatUserId",
                table: "Companies",
                column: "CreatUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_ModifyUserId",
                table: "Companies",
                column: "ModifyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
