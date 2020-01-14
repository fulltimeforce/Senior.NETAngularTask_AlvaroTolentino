using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fulltime.Application.Student.Commands.CreateStudentRecords
{
    public class CreateRecordsCommand: IRequest<StudentRecordsVm>
    {
        public ICollection<int> Records { get; set; }
    }
}