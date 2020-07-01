using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using UserModule.Model.RawModel;

namespace UserModule.Model
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
