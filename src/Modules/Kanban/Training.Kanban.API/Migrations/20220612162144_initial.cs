using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Training.Kanban.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    AlteredAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(26)", nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    AlteredAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    LeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_team_user_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "board",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    AlteredAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    LeaderId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_board", x => x.Id);
                    table.ForeignKey(
                        name: "FK_board_user_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_board_team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamUser",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamUser", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TeamUser_team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamUser_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardUser",
                columns: table => new
                {
                    BoardId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardUser", x => new { x.BoardId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BoardUser_board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardUser_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_board_LeaderId",
                table: "board",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_board_TeamId",
                table: "board",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardUser_UserId",
                table: "BoardUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_team_LeaderId",
                table: "team",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamUser_TeamId",
                table: "TeamUser",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_Username",
                table: "user",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_LoginData",
                table: "user",
                columns: new[] { "Username", "Password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardUser");

            migrationBuilder.DropTable(
                name: "TeamUser");

            migrationBuilder.DropTable(
                name: "board");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
