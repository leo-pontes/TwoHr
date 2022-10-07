using Volo.Abp.Application.Dtos;

namespace TwoHr.DTOs.Employees
{
    public class EmployeeGetListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
