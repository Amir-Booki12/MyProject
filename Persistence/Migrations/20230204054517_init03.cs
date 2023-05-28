using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "InsertByUserId", "InsertTime", "IsRemoved", "Name", "NormalizedName", "RemoveByUserId", "RemoveTime", "UpdateByUserId", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "88d3554b-3af6-4869-b5a1-218f1fbef6c6", "کاربر حقیقی", null, null, null, "UserReal", "USERREAL", null, null, null, null },
                    { 2, "678aa36f-43ac-4bdb-916f-207c87c2d904", "کاربر حقوقی", null, null, null, "UserLegal", "USERLEGAL", null, null, null, null },
                    { 3, "b25527eb-3677-482f-acd5-e142b3ae54a4", "ادمین کل سیستم", null, null, null, "AdminSystem", "ADMINSYSTEM", null, null, null, null },
                    { 4, "2506717e-a9bc-4d35-b17d-4466e9eda5ec", "ادمین کل سازمان", null, null, null, "AdminGeneralOrganization", "ADMINGENERALORGANIZATION", null, null, null, null },
                    { 5, "deb4afd2-4261-4a77-9978-53b748720e88", "ادمین سازمان", null, null, null, "AdminOrganization", "ADMINORGANIZATION", null, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
