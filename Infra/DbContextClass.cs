using MeuRastroCarbonoAPI.Models.Entities;
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
        public DbSet<SurveyEntity> Surveys { get; set; }
        public DbSet<AchievementEntity> Achievements { get; set; }
        public DbSet<EvolutionEntity> Evolutions { get; set; }
        public DbSet<EvolutionHistoryEntity> EvolutionsHistory { get; set; }
        public DbSet<UserAchievementEntity> UserAchivements { get; set; }
    }
}
