using Microsoft.EntityFrameworkCore;
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
        public DbSet<Operation> OPERATION { get; set; }
        public DbSet<Permission> PERMISSION { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            builder.Entity<Funcionality>()
                .HasOne(m => m.Module)
                .WithMany(f => f.Funcionalities)
                .HasForeignKey(k => k.ID_MODULE);

            builder.Entity<Permission>()
                .HasKey(k => new { k.ID_USER, k.ID_MODULE, k.ID_FUNCIONALITY, k.ID_OPERATION });

        }

    }
}
