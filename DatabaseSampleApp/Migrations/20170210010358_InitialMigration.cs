using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseSampleApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    WebsiteId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Foo1 = table.Column<string>(nullable: true),
                    Foo10 = table.Column<string>(nullable: true),
                    Foo2 = table.Column<string>(nullable: true),
                    Foo3 = table.Column<string>(nullable: true),
                    Foo4 = table.Column<string>(nullable: true),
                    Foo5 = table.Column<string>(nullable: true),
                    Foo6 = table.Column<string>(nullable: true),
                    Foo7 = table.Column<string>(nullable: true),
                    Foo8 = table.Column<string>(nullable: true),
                    Foo9 = table.Column<string>(nullable: true),
                    ServerId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.WebsiteId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    DomainUrl = table.Column<string>(nullable: true),
                    Foo1 = table.Column<string>(nullable: true),
                    Foo10 = table.Column<string>(nullable: true),
                    Foo2 = table.Column<string>(nullable: true),
                    Foo3 = table.Column<string>(nullable: true),
                    Foo4 = table.Column<string>(nullable: true),
                    Foo5 = table.Column<string>(nullable: true),
                    Foo6 = table.Column<string>(nullable: true),
                    Foo7 = table.Column<string>(nullable: true),
                    Foo8 = table.Column<string>(nullable: true),
                    Foo9 = table.Column<string>(nullable: true),
                    ServerId = table.Column<int>(nullable: true),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blogs_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "WebsiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    BlogId = table.Column<int>(nullable: false),
                    Foo1 = table.Column<string>(nullable: true),
                    Foo10 = table.Column<string>(nullable: true),
                    Foo2 = table.Column<string>(nullable: true),
                    Foo3 = table.Column<string>(nullable: true),
                    Foo4 = table.Column<string>(nullable: true),
                    Foo5 = table.Column<string>(nullable: true),
                    Foo6 = table.Column<string>(nullable: true),
                    Foo7 = table.Column<string>(nullable: true),
                    Foo8 = table.Column<string>(nullable: true),
                    Foo9 = table.Column<string>(nullable: true),
                    ServerId = table.Column<int>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topics_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Content = table.Column<string>(nullable: true),
                    Foo1 = table.Column<string>(nullable: true),
                    Foo10 = table.Column<string>(nullable: true),
                    Foo2 = table.Column<string>(nullable: true),
                    Foo3 = table.Column<string>(nullable: true),
                    Foo4 = table.Column<string>(nullable: true),
                    Foo5 = table.Column<string>(nullable: true),
                    Foo6 = table.Column<string>(nullable: true),
                    Foo7 = table.Column<string>(nullable: true),
                    Foo8 = table.Column<string>(nullable: true),
                    Foo9 = table.Column<string>(nullable: true),
                    ServerId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_WebsiteId",
                table: "Blogs",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_BlogId",
                table: "Topics",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Websites");
        }
    }
}
