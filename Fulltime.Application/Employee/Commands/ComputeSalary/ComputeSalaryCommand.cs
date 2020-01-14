using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fulltime.Application.Employee.Commands.ComputeSalary
{
    public class ComputeSalaryCommand: IRequest<EmployeeSalaryVm>
    {
        public string Name { get; set; }
        public double LaborOld { get; set; }
        public double TotalHours { get; set; }
    }
}
