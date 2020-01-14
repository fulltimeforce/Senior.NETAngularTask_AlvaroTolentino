using Fulltime.Application.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fulltime.Application.Employee.Commands.CreateRate
{
    public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, int>
    {
        private IFulltimeDbContext _context;
        public CreateRateCommandHandler(IFulltimeDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
            var rateHours = _context.RateHours.First();

            if (rateHours == null)
            {
                _context.RateHours.Add(new Domain.Employee.RateHour {
                    Rate = request.HourRate
                });
            }
            else
            {
                rateHours.Rate = request.HourRate;
            }

            return await _context.SaveChangesAsync(cancellationToken);
            
        }
    }
}
