using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class NewSystemErrorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAttahment_Attachments_AttachmentId",
                table: "QuestionAttahment");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAttahment_Questions_QuestionId",
                table: "QuestionAttahment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAttahment",
                table: "QuestionAttahment");

            migrationBuilder.RenameTable(
                name: "QuestionAttahment",
                newName: "QuestionAttahments");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAttahment_AttachmentId",
                table: "QuestionAttahments",
                newName: "IX_QuestionAttahments_AttachmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAttahments",
                table: "QuestionAttahments",
                columns: new[] { "QuestionId", "AttachmentId" });

            migrationBuilder.CreateTable(
                name: "SysExceptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysExceptions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAttahments_Attachments_AttachmentId",
                table: "QuestionAttahments",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAttahments_Questions_QuestionId",
                table: "QuestionAttahments",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAttahments_Attachments_AttachmentId",
                table: "QuestionAttahments");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAttahments_Questions_QuestionId",
                table: "QuestionAttahments");

            migrationBuilder.DropTable(
                name: "SysExceptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAttahments",
                table: "QuestionAttahments");

            migrationBuilder.RenameTable(
                name: "QuestionAttahments",
                newName: "QuestionAttahment");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAttahments_AttachmentId",
                table: "QuestionAttahment",
                newName: "IX_QuestionAttahment_AttachmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAttahment",
                table: "QuestionAttahment",
                columns: new[] { "QuestionId", "AttachmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAttahment_Attachments_AttachmentId",
                table: "QuestionAttahment",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAttahment_Questions_QuestionId",
                table: "QuestionAttahment",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
