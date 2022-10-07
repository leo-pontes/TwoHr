using System;
using System.Threading.Tasks;
using TwoHr.DTOs.Employees;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TwoHr.Employees
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task<EmployeeDto> GetAsync(Guid id);

        Task<PagedResultDto<EmployeeDto>> GetListAsync(EmployeeGetListDto input);

        Task<EmployeeDto> CreateAsync(EmployeeCreateUpdateDto input);

        Task UpdateAsync(Guid id, EmployeeCreateUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}
