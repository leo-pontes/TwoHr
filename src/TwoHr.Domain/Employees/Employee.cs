using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace TwoHr.Employees
{
    public class Employee : AuditedAggregateRoot<Guid>
    {
        #region Properties

        public string Name { get; private set; }

        public bool Active { get; set; }

        public DateTime BirthDate { get; private set; }

        public double Salary { get; private set; }

        #endregion

        #region Constructors

        private Employee() { }

        internal Employee(Guid id, string name, bool active, DateTime birthDate, double salary) : base(id)
        {
            ChangeName(name);
            ChangeBirthDate(birthDate);
            ChangeSalary(salary);

            Active = active;
        }

        #endregion

        #region Validations

        public bool NameIsValid(string name)
        {
            return (name.Length < EmployeeConsts.MaxNameLength && name.Length > EmployeeConsts.MinNameLength);
        }

        public bool BirthDateIsValid(DateTime birthDate)
        {
            return (birthDate <= DateTime.Now.AddYears((-1) * EmployeeConsts.MinYearsOld) &&
                    birthDate > DateTime.MinValue);
        }

        public bool SalaryIsValid(double salary)
        {
            return (salary < EmployeeConsts.MaxSalary && salary > EmployeeConsts.MinSalary);
        }

        #endregion

        #region Change Properties

        public void ChangeName(string name)
        {
            this.Name = NameIsValid(name) ? name : throw new EmployeeNameInvalidException(name);
        }

        public void ChangeBirthDate(DateTime birthDate)
        {
            this.BirthDate = BirthDateIsValid(birthDate) ? birthDate : throw new EmployeeBirthDateInvalidException(birthDate);
        }

        public void ChangeSalary(double salary)
        {
            this.Salary = SalaryIsValid(salary) ? salary : throw new EmployeeSalaryInvalidException(salary);
        }

        #endregion
    }

    internal class EmployeeFake
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Active { get; set; }

        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }

        internal Employee ConvertToEmployee()
        {
            return new Employee(Id, Name, Active, BirthDate, Salary);
        }
    }
}