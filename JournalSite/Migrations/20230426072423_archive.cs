using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JournalSite.Migrations
{
    /// <inheritdoc />
    public partial class archive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archive_Years",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive_Years", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archive_Numbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive_Numbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archive_Numbers_Archive_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Archive_Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archive_Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archive_Articles_Archive_Numbers_NumberId",
                        column: x => x.NumberId,
                        principalTable: "Archive_Numbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf18b32-aa40-457d-ace6-65892cbda144",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3edfd2ec-3403-4e37-9593-3f9a41fab77d", "AQAAAAIAAYagAAAAED2jR3ECJtYvqtnCJjIvHe+Dq+l0wLdH62q0oqLJ2LUFcqRKCBQX0lFmwLLSq+lbxQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2feb6b1-216b-4e2e-a65c-59a63dd08607",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10ea69de-5d36-494e-ad84-883159a7a1a9", "AQAAAAIAAYagAAAAEJ3JdVZIw5fDJ/5Y1ReJ3LZkG+cbX+n/UmvXs77Dx7KSP7cvEU2JHkM6gJTsWxzMrA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Archive_Articles_NumberId",
                table: "Archive_Articles",
                column: "NumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Archive_Numbers_YearId",
                table: "Archive_Numbers",
                column: "YearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archive_Articles");

            migrationBuilder.DropTable(
                name: "Archive_Numbers");

            migrationBuilder.DropTable(
                name: "Archive_Years");

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
    }
}
