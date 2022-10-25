using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Migrations
{
    public partial class Update3TblUser_Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterViewModel",
                table: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "ConfrimPassword",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RegisterViewModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RegisterViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "RegisterViewModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterViewModel",
                table: "RegisterViewModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterViewModel",
                table: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "RegisterViewModel");

            migrationBuilder.AddColumn<string>(
                name: "ConfrimPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RegisterViewModel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterViewModel",
                table: "RegisterViewModel",
                column: "Email");
        }
    }
}
