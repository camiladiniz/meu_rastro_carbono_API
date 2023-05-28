using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuRastroCarbonoAPI.Migrations
{
    public partial class OtherAnswerEntitiesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectronicSurveyAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CellphoneUsageInHours = table.Column<double>(type: "float", nullable: false),
                    ComputerTurnedOnInMinutes = table.Column<double>(type: "float", nullable: false),
                    ComputerCoreType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerCoresAmount = table.Column<int>(type: "int", nullable: true),
                    ComputerCPUModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerGPUModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerAvailableMemory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreamingUsageInMinutes = table.Column<double>(type: "float", nullable: false),
                    LampsOperationTime = table.Column<double>(type: "float", nullable: false),
                    LampType = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsumptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurveyType = table.Column<int>(type: "int", nullable: false),
                    CarbonEmissionInKgCO2e = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicSurveyAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectronicSurveyAnswers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodSurveyAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealPortionsAmount = table.Column<int>(type: "int", nullable: false),
                    MealsAmount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsumptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurveyType = table.Column<int>(type: "int", nullable: false),
                    CarbonEmissionInKgCO2e = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSurveyAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodSurveyAnswers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocomotionSurveyAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportType = table.Column<int>(type: "int", nullable: false),
                    MotorcycleFuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotorCycleMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarFuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarElectricFuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarHybridFuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarHybridAutonomy = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsumptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurveyType = table.Column<int>(type: "int", nullable: false),
                    CarbonEmissionInKgCO2e = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocomotionSurveyAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocomotionSurveyAnswers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicSurveyAnswers_UserId",
                table: "ElectronicSurveyAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSurveyAnswers_UserId",
                table: "FoodSurveyAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LocomotionSurveyAnswers_UserId",
                table: "LocomotionSurveyAnswers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectronicSurveyAnswers");

            migrationBuilder.DropTable(
                name: "FoodSurveyAnswers");

            migrationBuilder.DropTable(
                name: "LocomotionSurveyAnswers");
        }
    }
}
