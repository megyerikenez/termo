using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Termo.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BourdonTests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    incorrectlyMarked = table.Column<int>(type: "INTEGER", nullable: false),
                    incorrectlyIgnored = table.Column<int>(type: "INTEGER", nullable: false),
                    correctlyMarked = table.Column<int>(type: "INTEGER", nullable: false),
                    correctlyIgnored = table.Column<int>(type: "INTEGER", nullable: false),
                    linesViewed = table.Column<int>(type: "INTEGER", nullable: false),
                    charsViewed = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TestId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BourdonTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BourdonTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChairLampTests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TestId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChairLampTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChairLampTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToulousePieronTests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    IncorrectlyMarked = table.Column<int>(type: "INTEGER", nullable: false),
                    IncorrectlyIgnored = table.Column<int>(type: "INTEGER", nullable: false),
                    CorrectlyMarked = table.Column<int>(type: "INTEGER", nullable: false),
                    CorrectlyIgnored = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TestId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToulousePieronTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToulousePieronTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChairLampTestItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Minute = table.Column<int>(type: "INTEGER", nullable: false),
                    IncorrectlyIgnored = table.Column<int>(type: "INTEGER", nullable: false),
                    IncorrectlyMarked = table.Column<int>(type: "INTEGER", nullable: false),
                    CorrectlyMarked = table.Column<int>(type: "INTEGER", nullable: false),
                    CorrectlyIgnored = table.Column<int>(type: "INTEGER", nullable: false),
                    PicturesRevised = table.Column<int>(type: "INTEGER", nullable: false),
                    ChairLampTestId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChairLampTestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChairLampTestItems_ChairLampTests_ChairLampTestId",
                        column: x => x.ChairLampTestId,
                        principalTable: "ChairLampTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BourdonTests_TestId",
                table: "BourdonTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_ChairLampTestItems_ChairLampTestId",
                table: "ChairLampTestItems",
                column: "ChairLampTestId");

            migrationBuilder.CreateIndex(
                name: "IX_ChairLampTests_TestId",
                table: "ChairLampTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToulousePieronTests_TestId",
                table: "ToulousePieronTests",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BourdonTests");

            migrationBuilder.DropTable(
                name: "ChairLampTestItems");

            migrationBuilder.DropTable(
                name: "ToulousePieronTests");

            migrationBuilder.DropTable(
                name: "ChairLampTests");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
