using Microsoft.EntityFrameworkCore;
using AccessHomes.Domain.Entities;
using System.Threading.Tasks;

namespace AccessHomes.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Properties> Properties { get; set; }
        DbSet<Amenities> Amenities { get; set; }
        DbSet<Attachments> Attachments { get; set; }
        DbSet<Inspection> Inspection { get; set; }
        DbSet<Loan> Loan { get; set; }
        DbSet<Ratings> Ratings { get; set; }
        DbSet<TargetSavings> TargetSavings { get; set; }
        DbSet<Transaction> Transaction { get; set; }



        Task<int> SaveChangesAsync();
        int SaveChanges2();
    }
}