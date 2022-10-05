using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace TwoHr.Employees
{
    public class Employee : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }
    }
}
