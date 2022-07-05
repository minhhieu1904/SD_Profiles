using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public partial class DBContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Faq> Faq { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Subscribe> Subscribe { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.SetCommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(e => e.Id).HasColumnName("UserId");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            
            modelBuilder.Entity<About>(entity =>
            {
                entity.Property(e => e.Phone).IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Phone).IsUnicode(false);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Phone).IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.BadgeType).IsUnicode(false);

                entity.Property(e => e.BadgeValue).IsUnicode(false);

                entity.Property(e => e.Icon).IsUnicode(false);

                entity.Property(e => e.Path).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });
        }
    }
}