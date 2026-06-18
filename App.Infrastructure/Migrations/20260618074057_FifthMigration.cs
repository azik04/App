using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Worker_WorkersId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Worker_WorkersId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_WorkersId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Address_WorkersId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "WorkersId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkersId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_WorkerId",
                table: "Address",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Worker_WorkerId",
                table: "Address",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Worker_WorkerId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_WorkerId",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkersId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkersId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkersId",
                table: "Jobs",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_WorkersId",
                table: "Address",
                column: "WorkersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Worker_WorkersId",
                table: "Address",
                column: "WorkersId",
                principalTable: "Worker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Worker_WorkersId",
                table: "Jobs",
                column: "WorkersId",
                principalTable: "Worker",
                principalColumn: "Id");
        }
    }
}
