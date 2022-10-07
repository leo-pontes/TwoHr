using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace TwoHr.Employees
{
    public class EmployeeService : DomainService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateAsync([NotNull] string name, bool active, DateTime birthDate, double salary)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var employeeDb = await _employeeRepository.FindByNameAsync(name);

            if (employeeDb != null)
                throw new EmployeeAlreadyExistsException(name);

            return new Employee(GuidGenerator.Create(), name, active, birthDate, salary );
        }

        public async Task<Employee> UpdateAsync([NotNull] Guid id, [NotNull] string newName, bool newActive, DateTime newBirthDate, double newSalary)
        {
            Check.NotNull(id, nameof(id));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var employeeDb = await _employeeRepository.FindByNameAsync(newName);
            if (employeeDb != null && employeeDb.Id != id)
                throw new EmployeeAlreadyExistsException(newName);

            employeeDb.ChangeName(newName);
            employeeDb.ChangeBirthDate(newBirthDate);
            employeeDb.ChangeSalary(newSalary);

            employeeDb.Active = newActive;

            return employeeDb;
        }
    }
}
