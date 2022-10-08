using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TwoHr.DTOs.Employees;
using TwoHr.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace TwoHr.Employees
{
    [Authorize(TwoHrPermissions.Employees.Default)]
    public class EmployeeAppService : TwoHrAppService, IEmployeeAppService, ITransientDependency
    {
        private readonly IEmployeeRepository _repository;
        private readonly EmployeeService _domainService;
        private readonly IDistributedCache<EmployeeDto> _cache;
        private readonly IDistributedCache<PagedResultDto<EmployeeDto>> _cacheList;

        public EmployeeAppService(IEmployeeRepository employeeRepository, EmployeeService employeeService, 
            IDistributedCache<EmployeeDto> cache, IDistributedCache<PagedResultDto<EmployeeDto>> cacheList)
        {
            _repository = employeeRepository;
            _domainService = employeeService;
            _cache = cache;
            _cacheList = cacheList;
        }

        public async Task<EmployeeDto> GetAsync(Guid id)
        {
            return await _cache.GetOrAddAsync(
                id.ToString(), //Cache key
                async () => ObjectMapper.Map<Employee, EmployeeDto>(await _repository.GetAsync(id)),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
                }
            );
        }

        public async Task<PagedResultDto<EmployeeDto>> GetListAsync(EmployeeGetListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
                input.Sorting = nameof(Employee.Name);

            return await _cacheList.GetOrAddAsync(
                input.ToString(), //Cache key
                async () => await GetListFromDbAsync(input),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
                }
            );
        }

        public async Task<PagedResultDto<EmployeeDto>> GetListFromDbAsync(EmployeeGetListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
                input.Sorting = nameof(Employee.Name);

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
