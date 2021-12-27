using Microsoft.EntityFrameworkCore;
using AccessHomes.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AccessHomes.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using AccessHomes.Persistence.Seeds;

namespace AccessHomes.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Properties> Properties { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Attachments> Attachments { get; set; }
        public DbSet<Inspection> Inspection { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<TargetSavings> TargetSavings { get; set; }
        public DbSet<Transaction> Transaction { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Properties>()
           .Property(u => u.Status)
           .HasConversion<string>();

            modelBuilder.Entity<Properties>()
           .Property(u => u.Type)
           .HasConversion<string>();

            modelBuilder.Entity<Properties>()
           .Property(u => u.Duration)
           .HasConversion<string>();

            modelBuilder.Entity<Properties>()
           .Property(u => u.Bedrooms)
           .HasConversion<string>();

            modelBuilder.Entity<Properties>()
           .Property(u => u.Bathrooms)
           .HasConversion<string>();

            modelBuilder.Entity<Properties>()
           .Property(u => u.ParkingLot)
           .HasConversion<string>();

            modelBuilder.Entity<Properties>()
           .Property(u => u.Country)
           .HasConversion<string>();

            modelBuilder.Entity<Properties>()
           .Property(u => u.State)
           .HasConversion<string>();

            modelBuilder.Entity<Properties>()
           .Property(u => u.City)
           .HasConversion<string>();

            modelBuilder.Entity<Amenities>()
           .Property(u => u.Amenity)
           .HasConversion<string>();

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("DataSource=app.db");
            }

        } 

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public int SaveChanges2()
        {
            return base.SaveChanges();
        }
    }
}