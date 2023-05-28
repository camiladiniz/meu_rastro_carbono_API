namespace MeuRastroCarbonoAPI.Models.Response
{
    public class MetricsResponse
    {
        public int ShowersMedia { get; set; }
        public double ShowersEmissionByGPerCO2 { get; set; }
        public double CarDistanceTraveled { get; set; }
        public double CarEmissionByGPerCO2 { get; set; }
        public double FoodEmissionByGPerCO2 { get; set; }
        public double PhoneInChargeInHours { get; set; }
        public double PhoneEmissionByGPerCO2 { get; set; }
        public double LampsEmissionByGPerCO2 { get; set; }
        public double LampsOperationTimeInHours { get; set; }
        public double ComputerTurnedOnInMinutes { get; set; }
        public double ComputerEmissionByGPerCO2 { get; set; }
        public double StreamingEmissionByGPerCO2 { get; set; }
        public double StreamingTimeInHours { get; set; }
        public double TotalCarbonEmissionsInG { get; set; }
        public int TreesAmountToCompensate { get; set; }
        public int TreesAmountToCompensateInAYear { get; set; }
    }
}
