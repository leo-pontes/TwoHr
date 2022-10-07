using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwoHr.DTOs.Employees;
using TwoHr.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace TwoHr.Employees
{
    [Authorize(TwoHrPermissions.Employees.Default)]
    public class EmployeeAppService : TwoHrAppService, IEmployeeAppService
    {
        private readonly IEmployeeRepository _repository;
        private readonly EmployeeService _domainService;

        public EmployeeAppService(IEmployeeRepository employeeRepository, EmployeeService employeeService)
        {
            _repository = employeeRepository;
            _domainService = employeeService;
        }

        public async Task<EmployeeDto> GetAsync(Guid id)
        {
            var employee = await _repository.GetAsync(id);
            return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task<PagedResultDto<EmployeeDto>> GetListAsync(EmployeeGetListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Employee.Name);
            }

            var employees = await _repository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(x => x.Name.Contains(input.Filter));

            return new PagedResultDto<EmployeeDto>(totalCount, ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(employees));
        }

        [Authorize(TwoHrPermissions.Employees.Create)]
        public async Task<EmployeeDto> CreateAsync(EmployeeCreateUpdateDto input)
        {
            var employee = await _domainService.CreateAsync(input.Name, input.Active, input.BirthDate, input.Salary);

            await _repository.InsertAsync(employee);

            return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }

        [Authorize(TwoHrPermissions.Employees.Edit)]
        public async Task UpdateAsync(Guid id, EmployeeCreateUpdateDto input)
        {
            var employee = await _domainService.UpdateAsync(id, input.Name, input.Active, input.BirthDate, input.Salary);            

            await _repository.UpdateAsync(employee);
        }

        [Authorize(TwoHrPermissions.Employees.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
