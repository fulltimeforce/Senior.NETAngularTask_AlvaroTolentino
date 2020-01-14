using Fulltime.Domain.Common;
using System.Collections.Generic;

namespace Fulltime.Domain.Employee
{
    public class RateHour: AuditableEntity
    {
        public RateHour()
        {
            Salaries = new HashSet<EmployeeSalary>();
        }
        public int RateId { get; set; }
        public double Rate { get; set; }

        public ICollection<EmployeeSalary> Salaries { get; set; }
    }
}
