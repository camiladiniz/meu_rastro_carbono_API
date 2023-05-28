using MeuRastroCarbonoAPI.Models.Enums;

namespace MeuRastroCarbonoAPI.Models.Payload.Tips
{
    public class TipsModel
    {
        public string Title { get; set; }
        public SurveyType Type { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int Level { get; set; }
        public TipCategory Category { get; set; }

        public TipsModel(string title, SurveyType type, TipCategory category, string description, string source)
        {
            Title = title;
            Type = type;
            Category = category;
            Description = description;
            Source = source;
        }

        public enum TipCategory
        {
            // specifisc
            Car,
            Motorcycle,
            EtanolFuelCar,
            IncandescentLamp,
            ShowerBath,
            //generals
            Water,
            Computer,
            FoodShop,
            Cellphone,
            Electricity,
        }
    }
}
