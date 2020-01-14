using System;

namespace Fulltime.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
