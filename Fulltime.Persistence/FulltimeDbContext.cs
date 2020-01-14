using Fulltime.Application.Common.Interfaces;
using Fulltime.Domain.Common;
using Fulltime.Domain.Employee;
using Fulltime.Domain.Palindrome;
using Fulltime.Domain.Student;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fulltime.Persistence
{
    public class FulltimeDbContext : DbContext, IFulltimeDbContext
    {
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<RateHour> RateHours { get; set; }
        public DbSet<PalindromeWord> PalindromeWords { get; set; }
        public DbSet<Record> Records { get; set; }


        public FulltimeDbContext(DbContextOptions<FulltimeDbContext> options)
            : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.Updated = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        break;

                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
