using MeuRastroCarbonoAPI.Models.Enums;
using static MeuRastroCarbonoAPI.Models.Payload.Tips.TipsModel;

namespace MeuRastroCarbonoAPI.Models.Payload.Rewards
{
    public class RewardsModel
    {
        public string Title { get; set; }
        public SurveyType Type { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public RewardsModel(string title, SurveyType type, string description, bool isActive)
        {
            Title = title;
            Type = type;
            Description = description;
            IsActive = isActive;
        }
    }
}
