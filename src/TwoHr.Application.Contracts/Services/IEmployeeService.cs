using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TwoHr.Employees
{
    public interface IEmployeeService : ICrudAppService<EmployeeDto, Guid, PagedAndSortedResultRequestDto, EmployeeCreateUpdateDto>
    {
    }
}
