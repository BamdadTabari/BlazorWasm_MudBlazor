using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace illegible.DataStructure.Migrations
{
    public partial class DeleteBlogPostContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostContent",
                schema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "AttachedLinkTypeEnum",
                schema: "dbo",
                table: "BlogPost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostAttachedFileUrl",
                schema: "dbo",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostAttachedLinkUrl",
                schema: "dbo",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostContext",
                schema: "dbo",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostImageUrl",
                schema: "dbo",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostVideoUrl",
                schema: "dbo",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachedLinkTypeEnum",
                schema: "dbo",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "PostAttachedFileUrl",
                schema: "dbo",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "PostAttachedLinkUrl",
                schema: "dbo",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "PostContext",
                schema: "dbo",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "PostImageUrl",
                schema: "dbo",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "PostVideoUrl",
                schema: "dbo",
                table: "BlogPost");

            migrationBuilder.CreateTable(
                name: "BlogPostContent",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachedLinkTypeEnum = table.Column<int>(type: "int", nullable: false),
                    BlogPostId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostAttachedFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostAttachedLinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostContent_BlogPost_BlogPostId",
                        column: x => x.BlogPostId,
                        principalSchema: "dbo",
                        principalTable: "BlogPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostContent_BlogPostId",
                schema: "dbo",
                table: "BlogPostContent",
                column: "BlogPostId",
                unique: true);
        }
    }
}
