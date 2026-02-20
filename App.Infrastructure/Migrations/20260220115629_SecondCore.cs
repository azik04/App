using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Client_ClientsId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ClientsId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientId",
                table: "Address",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Client_ClientId",
                table: "Address",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Client_ClientId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ClientId",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientsId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientsId",
                table: "Address",
                column: "ClientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Client_ClientsId",
                table: "Address",
                column: "ClientsId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
