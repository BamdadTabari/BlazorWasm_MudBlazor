using Microsoft.EntityFrameworkCore.Migrations;

namespace illegible.DataStructure.Migrations
{
    public partial class DoItMoreSimpleForNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachedLinkTypeEnum",
                schema: "dbo",
                table: "BlogPost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachedLinkTypeEnum",
                schema: "dbo",
                table: "BlogPost",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
