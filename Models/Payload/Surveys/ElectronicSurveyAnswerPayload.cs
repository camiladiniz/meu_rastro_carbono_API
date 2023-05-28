﻿using MeuRastroCarbonoAPI.Models.Entities;
using MeuRastroCarbonoAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Payload.Surveys
{
    public class ElectronicSurveyAnswerPayload
    {
        public Guid UserId { get; set; }
        [Required]
        public DateTime ConsumptionDate { get; set; }

        [Required]
        public double CarbonEmissionInKgCO2e { get; set; }

        [Required]
        public double CellphoneUsageInHours { get; set; }

        [Required]
        public double ComputerTurnedOnInMinutes { get; set; }

        public string? ComputerCoreType { get; set; }

        public int? ComputerCoresAmount { get; set; }

        public string? ComputerCPUModel { get; set; }

        public string? ComputerGPUModel { get; set; }

        public string? ComputerAvailableMemory { get; set; }

        [Required]
        public double StreamingUsageInMinutes { get; set; }

        [Required]
        public double LampsOperationTime { get; set; }

        [Required]
        public string LampType { get; set; }

        public double PhoneCarbonEmissionInKgCO2e { get; set; }
        public double ComputerCarbonEmissionInKgCO2e { get; set; }
        public double StreamingCarbonEmissionInKgCO2e { get; set; }
        public double LampCarbonEmissionInKgCO2e { get; set; }
    }
}
