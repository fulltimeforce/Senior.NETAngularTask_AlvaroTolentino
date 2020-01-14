using FluentValidation;

namespace Fulltime.Application.Employee.Commands.CreateRate
{
    public class CreateRateCommandValidation: AbstractValidator<CreateRateCommand>
    {
        public CreateRateCommandValidation()
        {
            RuleFor(x => x.HourRate).GreaterThan(0);
        }
    }
}
