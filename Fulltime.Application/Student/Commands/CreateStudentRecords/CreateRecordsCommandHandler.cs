using Fulltime.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fulltime.Application.Student.Commands.CreateStudentRecords
{
    public class CreateRecordsCommandHandler : IRequestHandler<CreateRecordsCommand, StudentRecordsVm>
    {

        private IFulltimeDbContext _context;
        public CreateRecordsCommandHandler(IFulltimeDbContext context)
        {
            _context = context;
        }

        public async Task<StudentRecordsVm> Handle(CreateRecordsCommand request, CancellationToken cancellationToken)
        {
            foreach (var record in request.Records)
            {
                _context.Records.Add(new Domain.Student.Record
                {
                    Value = record
                });
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new StudentRecordsVm
            {
                Approved = request.Records.Where(x => x > 51).Sum(x => x),
                Disapproved = request.Records.Where(x => x > 51).Sum(x => x),
                AverageScores = request.Records.Average(x => x)
            };

        }
    }
}
