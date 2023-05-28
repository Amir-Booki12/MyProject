using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UpdateByUserId",
                table: "AspNetUsers",
                newName: "RegistrationNumber");

            migrationBuilder.RenameColumn(
                name: "RemoveTime",
                table: "AspNetUsers",
                newName: "CompanyRegistrationDate");

            migrationBuilder.RenameColumn(
                name: "RemoveByUserId",
                table: "AspNetUsers",
                newName: "NationalId");

            migrationBuilder.RenameColumn(
                name: "InsertByUserId",
                table: "AspNetUsers",
                newName: "NationalCode");

            migrationBuilder.AddColumn<int>(
                name: "BirthCertificatId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyRegistrationPlace",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EconomicCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstablishedYear",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NatureTypeUser",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthCertificatId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyRegistrationPlace",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EconomicCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EstablishedYear",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NatureTypeUser",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RegistrationNumber",
                table: "AspNetUsers",
                newName: "UpdateByUserId");

            migrationBuilder.RenameColumn(
                name: "NationalId",
                table: "AspNetUsers",
                newName: "RemoveByUserId");

            migrationBuilder.RenameColumn(
                name: "NationalCode",
                table: "AspNetUsers",
                newName: "InsertByUserId");

            migrationBuilder.RenameColumn(
                name: "CompanyRegistrationDate",
                table: "AspNetUsers",
                newName: "RemoveTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }
    }
}
