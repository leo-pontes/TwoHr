using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwoHr.Employees;

namespace TwoHr.Web.Pages.Employees
{
    public class CreateModalModel : TwoHrPageModel
    {
        [BindProperty]
        public EmployeeCreateUpdateDto Employee { get; set; }

        private readonly IEmployeeAppService _employeeAppService;

        public CreateModalModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public void OnGet()
        {
            Employee = new EmployeeCreateUpdateDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeAppService.CreateAsync(Employee);
            return NoContent();
        }
    }
}
