using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fulltime.Application.Student.Commands.CreateStudentRecords
{
    public class CreateRecordsCommandValidation: AbstractValidator<CreateRecordsCommand>
    {
        public CreateRecordsCommandValidation()
        {
            RuleFor(x => x.Records).NotEmpty();
        }
    }
}
