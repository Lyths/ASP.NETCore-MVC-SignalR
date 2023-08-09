using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JournalSite.Migrations
{
    /// <inheritdoc />
    public partial class addid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf18b32-aa40-457d-ace6-65892cbda144",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43f9913a-cfed-45c5-9dc6-b8139b9cd9a2", "AQAAAAIAAYagAAAAEEt12pIkl9DnMimlj8WlWaLveLcTBYf5XSxYqMt4Ft8YX1zkdLnbdpy2YEKIR+3CAA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2feb6b1-216b-4e2e-a65c-59a63dd08607",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32763f93-c628-4734-8f6c-c98ad40cb4b2", "AQAAAAIAAYagAAAAENNhyk3OWMbqEPsIJBwiNNEV/igMI1lELMkdD5JLIoaNGZH00NjJBjkHiZAgKVlTrg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
