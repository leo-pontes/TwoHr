using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TwoHr.Employees
{
    internal class EmployeeDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;

        public EmployeeDataSeeder(IRepository<Employee, Guid> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _employeeRepository.GetCountAsync() <= 0)
            {
                var faker = new Faker<EmployeeFake>("pt_BR")
                    .RuleFor(x => x.Id, y => Guid.NewGuid())
                    .RuleFor(x => x.Name, y => y.Name.FullName())
                    .RuleFor(x => x.Active, y => y.Random.Bool())
                    .RuleFor(x => x.BirthDate, y => y.Date.Between(DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-20)))
                    .RuleFor(x => x.Salary, y => y.Random.Double(1300, 50000));

                var employeeList = new List<Employee>();

                foreach (var item in faker.Generate(3))
                    employeeList.Add(item.ConvertToEmployee());                                               
                
                await _employeeRepository.InsertManyAsync(employeeList, autoSave: true);
            }
        }
    }
}
