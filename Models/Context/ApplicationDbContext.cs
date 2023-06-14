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
    }
}
