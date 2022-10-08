using Volo.Abp.Application.Dtos;

namespace TwoHr.DTOs.Employees
{
    public class EmployeeGetListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public override string ToString()
        {
            return this.Filter + '_' +
                this.MaxResultCount.ToString() + '_' +
                this.SkipCount.ToString() + '_' +
                this.Sorting.ToString();
        }
    }
}
