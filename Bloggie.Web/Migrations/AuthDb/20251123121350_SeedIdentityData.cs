using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class SeedIdentityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2290daa7-52fc-44a1-bd4a-d0dc60bede8d", "AQAAAAIAAYagAAAAEMFFgo5JrPSniaD+NcQ2/aYtfTq3PCedRIMGyoM0e4eXOUAQfkSQFub6xUHiazejMw==", "8c1a8fe2-90d3-402e-a854-d43456ff5f2c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42b4d5ae-f1d2-4b6a-bdad-e3a6e9a14806", "AQAAAAIAAYagAAAAENeVYXPlVWcL04nKCR1x2HDYySIinjTySikfnm4OIXcnRCXTdq212KSPpO8/na6HCg==", "c9236c11-2482-41c9-8192-999616bfdfb5" });
        }
    }
}
