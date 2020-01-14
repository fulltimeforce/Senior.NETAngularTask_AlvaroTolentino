using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fulltime.Application.Employee.Commands.CreateRate
{
    public class CreateRateCommand: IRequest<int>
    {
        public double HourRate { get; set; }
    }
}
