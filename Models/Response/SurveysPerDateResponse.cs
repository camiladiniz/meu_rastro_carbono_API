namespace MeuRastroCarbonoAPI.Models.Response
{
    public class SurveysPerDateResponse
    {
        public bool WaterSurvey { get; set; }
        public bool FoodSurvey { get; set; }
        public bool ElectronicSurvey { get; set; }
        public bool LocomotionSurvey { get; set; }
    }
}
