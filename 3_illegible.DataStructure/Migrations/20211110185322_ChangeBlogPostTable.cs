using Microsoft.EntityFrameworkCore.Migrations;

namespace illegible.DataStructure.Migrations
{
    public partial class ChangeBlogPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostAttachedFileUrl",
                schema: "dbo",
                table: "BlogPost",
                newName: "PostAttachedLinkUrlSubject");

            migrationBuilder.AlterColumn<string>(
                name: "PostContext",
                schema: "dbo",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttachedLinkTypeEnum",
                schema: "dbo",
                table: "BlogPost",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachedLinkTypeEnum",
                schema: "dbo",
                table: "BlogPost");

            migrationBuilder.RenameColumn(
                name: "PostAttachedLinkUrlSubject",
                schema: "dbo",
                table: "BlogPost",
                newName: "PostAttachedFileUrl");

            migrationBuilder.AlterColumn<string>(
                name: "PostContext",
                schema: "dbo",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
