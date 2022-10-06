using System;
using TwoHr.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TwoHr.Employees
{
    public class EmployeeService : CrudAppService<Employee, EmployeeDto, Guid, PagedAndSortedResultRequestDto, EmployeeCreateUpdateDto>, IEmployeeService
    {
        public EmployeeService(IRepository<Employee, Guid> repository) : base(repository)
        {
            GetPolicyName = TwoHrPermissions.Employees.Default;
            GetListPolicyName = TwoHrPermissions.Employees.Default;
            CreatePolicyName = TwoHrPermissions.Employees.Create;
            UpdatePolicyName = TwoHrPermissions.Employees.Edit;
            DeletePolicyName = TwoHrPermissions.Employees.Delete;
        }
    }
}
