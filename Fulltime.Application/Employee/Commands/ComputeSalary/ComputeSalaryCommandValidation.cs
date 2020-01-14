using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fulltime.Application.Employee.Commands.ComputeSalary
{
    public class ComputeSalaryCommandValidation: AbstractValidator<ComputeSalaryCommand>
    {
        public ComputeSalaryCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LaborOld).GreaterThan(0).NotEmpty();
            RuleFor(x=>x.TotalHours).GreaterThan(0).NotEmpty();
        }
    }
}
