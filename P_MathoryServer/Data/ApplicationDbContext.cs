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
        public DbSet<Ranking> Ranking { get; set; }
        public DbSet<MyPage> MyPage { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<StarCount> StarCount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 복합 기본 키 설정
            modelBuilder.Entity<Log>()
                .HasKey(l => new { l.UserId, l.Year, l.SubjectId });
            modelBuilder.Entity<MyPage>()
                .HasKey(l => new { l.UserId, l.Year, l.SubjectId });
            modelBuilder.Entity<StarCount>()
                .HasKey(s => s.UserId);
            modelBuilder.Entity<Quiz>()
               .HasKey(s => s.Id);

            // 외래 키 설정
            modelBuilder.Entity<Log>()
                .HasOne(l => l.UserInformation) 
                .WithMany()  
                .HasForeignKey(l => l.UserId)  
                .HasPrincipalKey(ui => ui.UserId);
            modelBuilder.Entity<Log>()
                .HasOne(l => l.Subject) 
                .WithMany()  
                .HasForeignKey(l => l.SubjectId);  
            modelBuilder.Entity<MyPage>()
                .HasOne(l => l.UserInformation)
                .WithMany()  
                .HasForeignKey(l => l.UserId)  
                .HasPrincipalKey(ui => ui.UserId);
            modelBuilder.Entity<MyPage>()
                .HasOne(l => l.Subject)
                .WithMany()
                .HasForeignKey(l => l.SubjectId);
            modelBuilder.Entity<StarCount>()
                .HasOne(s => s.UserInformation)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .HasPrincipalKey(ui => ui.UserId);
            modelBuilder.Entity<Quiz>()
                .HasOne(s => s.Subject)
                .WithMany()
                .HasForeignKey(s => s.SubjectId);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }
    }
}
