using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JournalSite.Migrations
{
    /// <inheritdoc />
    public partial class asds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_GroupId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf18b32-aa40-457d-ace6-65892cbda144",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c533dbdd-f75d-4923-bde4-ac071752428b", "AQAAAAIAAYagAAAAEMQZCTefUgutECSR2C3wX9jopHRgs9i9uCDZV3aVx7HJ1CpubhT/zDSj5K6awU5b2g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2feb6b1-216b-4e2e-a65c-59a63dd08607",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02f29855-2bcc-4854-9501-467df33c8fab", "AQAAAAIAAYagAAAAEMfgdL0duicSB15hMAw+uZ5lc9N7X/Hp/5Zuv2NJB4UhZd+LdAalxXNem0Abq0q+7A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf18b32-aa40-457d-ace6-65892cbda144",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40bee314-0cbe-4aef-8cb2-5bb9b76ef34a", "AQAAAAIAAYagAAAAEO2GSyYiPEXOz1RRF/UOmKWluZ8fON3j5rEo/nHrKye2tfkzSfyL0KErsJSAs6BVdw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2feb6b1-216b-4e2e-a65c-59a63dd08607",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1588a63c-518a-4a53-a93f-1c60d5fe6813", "AQAAAAIAAYagAAAAEFVGKmqvTWSIm41K1FuyS0cYdHNSx4QlJOlUkBe4Ib2baLU5piRz7s4XxE7EbqfDjw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupId",
                table: "Messages",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
