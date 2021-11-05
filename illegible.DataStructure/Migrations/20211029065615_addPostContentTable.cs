using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace illegible.DataStructure.Migrations
{
    public partial class addPostContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPostContent",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostAttachedFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachedLinkTypeEnum = table.Column<int>(type: "int", nullable: false),
                    PostAttachedLinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogPostId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostContent",
                schema: "dbo");
        }
    }
}
