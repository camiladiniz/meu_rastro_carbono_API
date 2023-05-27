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
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<UserEntity> Users { get; set; }
    }
}
