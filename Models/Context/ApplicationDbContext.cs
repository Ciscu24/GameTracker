using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Models.Context
{
    public class ApplicationDbContext: DbContext
    {
        #region DbSets

        public DbSet<UserModel> UsersDb { get; set; }

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Following)
                .UsingEntity(j => j.ToTable("FollowUser"));
        }
    }
}
