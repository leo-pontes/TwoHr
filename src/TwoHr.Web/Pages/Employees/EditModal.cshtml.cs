using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TwoHr.Employees;

namespace TwoHr.Web.Pages.Employees
{
    public class EditModalModel : TwoHrPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public EmployeeCreateUpdateDto Employee { get; set; }

        private readonly IEmployeeService _employeeService;

        public EditModalModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task OnGetAsync()
        {
            var employeeDto = await _employeeService.GetAsync(Id);
            Employee = ObjectMapper.Map<EmployeeDto, EmployeeCreateUpdateDto>(employeeDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeService.UpdateAsync(Id, Employee);
            return NoContent();
        }
    }
}
