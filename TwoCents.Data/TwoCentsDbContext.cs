using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TwoCents.Data.Entities;

namespace TwoCents.Data
{
    public class TwoCentsDbContext : DbContext
    {
        private readonly string _connectionString;

        public TwoCentsDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PetitionEntity> Petitions { get; set; }
        public DbSet<PetitionCommentEntity> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
