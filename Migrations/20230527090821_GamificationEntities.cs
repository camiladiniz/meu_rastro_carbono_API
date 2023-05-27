using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuRastroCarbonoAPI.Migrations
{
    public partial class GamificationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EvolutionId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evolutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPontuation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAchivements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AchievementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchivements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAchivements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAchivements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvolutionsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pontuation = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolutionsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvolutionsHistory_Evolutions_EvolutionId",
                        column: x => x.EvolutionId,
                        principalTable: "Evolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EvolutionId",
                table: "Users",
                column: "EvolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvolutionsHistory_EvolutionId",
                table: "EvolutionsHistory",
                column: "EvolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchivements_AchievementId",
                table: "UserAchivements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchivements_UserId",
                table: "UserAchivements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Evolutions_EvolutionId",
                table: "Users",
                column: "EvolutionId",
                principalTable: "Evolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Evolutions_EvolutionId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "EvolutionsHistory");

            migrationBuilder.DropTable(
                name: "UserAchivements");

            migrationBuilder.DropTable(
                name: "Evolutions");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Users_EvolutionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EvolutionId",
                table: "Users");
        }
    }
}
