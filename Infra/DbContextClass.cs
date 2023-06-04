using MeuRastroCarbonoAPI.Models.Entities;
using MeuRastroCarbonoAPI.Models.Entities.Account;
using MeuRastroCarbonoAPI.Models.Entities.Surveys;
using Microsoft.EntityFrameworkCore;


namespace MeuRastroCarbonoAPI.Infra
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration["DefaultConnection"]);
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PasswordRenewCodeEntity> PasswordRenewCodes { get; set; }
        public DbSet<WaterSurveyAnswerEntity> WaterSurveyAnswers { get; set; }
        public DbSet<FoodSurveyAnswerEntity> FoodSurveyAnswers { get; set; }
        public DbSet<ElectronicSurveyAnswerEntity> ElectronicSurveyAnswers { get; set; }
        public DbSet<LocomotionSurveyAnswerEntity> LocomotionSurveyAnswers { get; set; }
        public DbSet<AchievementEntity> Achievements { get; set; }
        public DbSet<EvolutionEntity> Evolutions { get; set; }
        public DbSet<EvolutionHistoryEntity> EvolutionsHistory { get; set; }
        public DbSet<UserAchievementEntity> UserAchivements { get; set; }
    }
}
