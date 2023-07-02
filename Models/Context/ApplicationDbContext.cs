using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Models.Context
{
    public class ApplicationDbContext: DbContext
    {
        #region DbSets

        public DbSet<UserModel> UsersDb { get; set; }

        public DbSet<GameModel> GamesDb { get; set; }

        public DbSet<PlayerGameStatusModel> PlayerGameStatusDb { get; set; }

        public DbSet<CollectionModel> CollectionsDb { get; set; }

        public DbSet<CommentModel> CommentsDb { get; set; }

        public DbSet<ConsoleModel> ConsolesDb { get; set; }

        public DbSet<GenreModel> GenresDb { get; set; }

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Following)
                .UsingEntity(j => j.ToTable("FollowUser"));

            modelBuilder.Entity<CollectionModel>()
                .HasMany(c => c.Games)
                .WithMany(c => c.Collections)
                .UsingEntity(e => e.ToTable("CollectionsGames"));

            modelBuilder.Entity<ConsoleModel>()
                .HasMany(c => c.Games)
                .WithMany(c => c.Consoles)
                .UsingEntity(e => e.ToTable("ConsolesGames"));

            modelBuilder.Entity<GenreModel>()
                .HasMany(c => c.Games)
                .WithMany(c => c.Genres)
                .UsingEntity(e => e.ToTable("GenresGames"));

            modelBuilder.Entity<PlayerGameStatusModel>()
                .HasKey(pgs => new { pgs.UserId, pgs.GameId });
        }
    }
}
