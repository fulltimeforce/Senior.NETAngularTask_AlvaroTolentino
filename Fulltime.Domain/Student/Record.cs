using Fulltime.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fulltime.Domain.Student
{
    public class Record: AuditableEntity
    {
        public int RecordId { get; set; }
        public int Value { get; set; }
    }
}
