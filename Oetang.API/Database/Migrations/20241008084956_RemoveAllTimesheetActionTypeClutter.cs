using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oetang.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAllTimesheetActionTypeClutter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimesheetAction_TimeEntry_TimeEntryId",
                table: "TimesheetAction");

            migrationBuilder.DropIndex(
                name: "IX_TimesheetAction_TimeEntryId",
                table: "TimesheetAction");

            migrationBuilder.DropColumn(
                name: "TimeEntryId",
                table: "TimesheetAction");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "TimesheetAction",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TimesheetAction",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "TimeEntryId",
                table: "TimesheetAction",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetAction_TimeEntryId",
                table: "TimesheetAction",
                column: "TimeEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimesheetAction_TimeEntry_TimeEntryId",
                table: "TimesheetAction",
                column: "TimeEntryId",
                principalTable: "TimeEntry",
                principalColumn: "Id");
        }
    }
}
