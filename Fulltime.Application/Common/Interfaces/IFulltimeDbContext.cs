using Fulltime.Domain.Employee;
using Fulltime.Domain.Palindrome;
using Fulltime.Domain.Student;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Fulltime.Application.Common.Interfaces
{
    public interface IFulltimeDbContext
    {

        DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        DbSet<RateHour> RateHours { get; set; }
        DbSet<PalindromeWord> PalindromeWords { get; set; }
        DbSet<Record> Records { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
