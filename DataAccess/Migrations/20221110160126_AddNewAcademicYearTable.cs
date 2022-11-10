using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddNewAcademicYearTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AcademicYearId",
                table: "Responses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AcademicYearId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicYears_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_AcademicYearId",
                table: "Responses",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AcademicYearId",
                table: "Questions",
                column: "AcademicYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AcademicYears_AcademicYearId",
                table: "Questions",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AcademicYears_AcademicYearId",
                table: "Responses",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AcademicYears_AcademicYearId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AcademicYears_AcademicYearId",
                table: "Responses");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropIndex(
                name: "IX_Responses_AcademicYearId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AcademicYearId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AcademicYearId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "AcademicYearId",
                table: "Questions");
        }
    }
}
