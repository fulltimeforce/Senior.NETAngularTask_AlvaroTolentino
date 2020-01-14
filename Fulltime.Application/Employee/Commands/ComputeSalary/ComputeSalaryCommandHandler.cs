using Fulltime.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Fulltime.Application.Common.Exceptions;
using Fulltime.Domain.Employee;

namespace Fulltime.Application.Employee.Commands.ComputeSalary
{
    public class ComputeSalaryCommandHandler : IRequestHandler<ComputeSalaryCommand, EmployeeSalaryVm>
    {
        private IFulltimeDbContext _context;
        public ComputeSalaryCommandHandler(IFulltimeDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeSalaryVm> Handle(ComputeSalaryCommand request, CancellationToken cancellationToken)
        {
            var rateHours = _context.RateHours.First();

            if (rateHours == null)
            {
                throw new NotFoundException(nameof(RateHour), string.Empty);
            }

            var employeeSalary = await _context.EmployeeSalaries.AddAsync(new EmployeeSalary
            {
                Name = request.Name,
                LaborOld = request.LaborOld,
                TotalHours = request.TotalHours,
                RateHour = rateHours
            });

            await _context.SaveChangesAsync(cancellationToken);

            return new EmployeeSalaryVm
            {
                Name = employeeSalary.Entity.Name,
                LaborOld = employeeSalary.Entity.LaborOld,
                RateHour = rateHours.Rate,
                GrossSalary = ComputeGrossSalary(rateHours.Rate, employeeSalary.Entity),
                Discount = ComputeDiscounts(rateHours.Rate, employeeSalary.Entity),
            };

        }

        private static double ComputeDiscounts(double rate, EmployeeSalary employeeSalary)
        {
            return (rate * employeeSalary.TotalHours) * 0.13;
        }

        private double ComputeGrossSalary(double rate, EmployeeSalary employeeSalary)
        {
            return (rate * employeeSalary.TotalHours) + (employeeSalary.LaborOld + 30);
        }
    }
}
