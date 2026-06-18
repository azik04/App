using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Address_StatusId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Status_StatusId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Worker_WorkerId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_StatusId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Jobs",
                newName: "WorkersId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_WorkerId",
                table: "Jobs",
                newName: "IX_Jobs_WorkersId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateAt",
                table: "Jobs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "WorkerJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkerJobs_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AddressId",
                table: "Jobs",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerJobs_JobId",
                table: "WorkerJobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerJobs_WorkerId",
                table: "WorkerJobs",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Address_AddressId",
                table: "Jobs",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Worker_WorkersId",
                table: "Jobs",
                column: "WorkersId",
                principalTable: "Worker",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Address_AddressId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Worker_WorkersId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "WorkerJobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_AddressId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "isDone",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ContactUs");

            migrationBuilder.RenameColumn(
                name: "WorkersId",
                table: "Jobs",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_WorkersId",
                table: "Jobs",
                newName: "IX_Jobs_WorkerId");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_StatusId",
                table: "Jobs",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Address_StatusId",
                table: "Jobs",
                column: "StatusId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Status_StatusId",
                table: "Jobs",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Worker_WorkerId",
                table: "Jobs",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
