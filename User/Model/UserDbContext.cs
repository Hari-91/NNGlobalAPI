using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UserModule.Model.RawModel;

namespace UserModule.Model
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Module> MODULE { get; set; }
        public DbSet<Funcionality> FUNCIONALITY { get; set; }
        public DbSet<JoinUserModule> USER_MODULE { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


            builder.Entity<JoinUserModule>()
                .HasKey(k => new { k.ID_USER, k.ID_MODULE });

            builder.Entity<Module>()
                .HasMany(f => f.Funcionality)
                .WithOne(m => m.Module)
                .HasForeignKey(k => k.ID_MODULE);


        }
    }
}
