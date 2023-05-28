using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuRastroCarbonoAPI.Migrations
{
    public partial class ElectronicMoreDetailedMetrics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ComputerCarbonEmissionInKgCO2e",
                table: "ElectronicSurveyAnswers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LampCarbonEmissionInKgCO2e",
                table: "ElectronicSurveyAnswers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PhoneCarbonEmissionInKgCO2e",
                table: "ElectronicSurveyAnswers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StreamingCarbonEmissionInKgCO2e",
                table: "ElectronicSurveyAnswers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerCarbonEmissionInKgCO2e",
                table: "ElectronicSurveyAnswers");

            migrationBuilder.DropColumn(
                name: "LampCarbonEmissionInKgCO2e",
                table: "ElectronicSurveyAnswers");

            migrationBuilder.DropColumn(
                name: "PhoneCarbonEmissionInKgCO2e",
                table: "ElectronicSurveyAnswers");

            migrationBuilder.DropColumn(
                name: "StreamingCarbonEmissionInKgCO2e",
                table: "ElectronicSurveyAnswers");
        }
    }
}
