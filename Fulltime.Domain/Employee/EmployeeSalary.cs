using Fulltime.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fulltime.Domain.Employee
{
    public class EmployeeSalary: AuditableEntity
    {
        public int EmployeeSalaryId { get; set; }
        public string Name { get; set; }
        public double LaborOld { get; set; }
        public double TotalHours { get; set; }
        public RateHour RateHour { get; set; }
    }
}
