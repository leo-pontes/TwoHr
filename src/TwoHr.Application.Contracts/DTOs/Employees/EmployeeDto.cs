using System;
using System.Threading;
using Volo.Abp.Application.Dtos;

namespace TwoHr.Employees
{
    public class EmployeeDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }

        public string SalaryFormated { get => Salary.ToString("C", Thread.CurrentThread.CurrentCulture); }
    }
}
