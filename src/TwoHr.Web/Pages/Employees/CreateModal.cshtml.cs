using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwoHr.Employees;

namespace TwoHr.Web.Pages.Employees
{
    public class CreateModalModel : TwoHrPageModel
    {
        [BindProperty]
        public EmployeeCreateUpdateDto Employee { get; set; }

        private readonly IEmployeeService _employeeService;

        public CreateModalModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void OnGet()
        {
            Employee = new EmployeeCreateUpdateDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeService.CreateAsync(Employee);
            return NoContent();
        }
    }
}
