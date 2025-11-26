using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafetyVision.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingNotificationProprites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Workers_ReciverWorkerId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "ReciverWorkerId",
                table: "Notifications",
                newName: "ReceiverWorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_ReciverWorkerId",
                table: "Notifications",
                newName: "IX_Notifications_ReceiverWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Workers_ReceiverWorkerId",
                table: "Notifications",
                column: "ReceiverWorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Workers_ReceiverWorkerId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "ReceiverWorkerId",
                table: "Notifications",
                newName: "ReciverWorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_ReceiverWorkerId",
                table: "Notifications",
                newName: "IX_Notifications_ReciverWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Workers_ReciverWorkerId",
                table: "Notifications",
                column: "ReciverWorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
