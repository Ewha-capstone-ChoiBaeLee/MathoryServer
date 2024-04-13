using Microsoft.EntityFrameworkCore;
using SharedData.Models;

namespace P_MathoryServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<CharacterInformation> CharacterInformation { get; set; }
        public DbSet<StoryLine> StoryLine { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Story> Story { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }
    }
}
