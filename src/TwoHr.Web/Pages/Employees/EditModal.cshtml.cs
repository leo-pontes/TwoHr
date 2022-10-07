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

        private readonly IEmployeeAppService _employeeAppService;

        public EditModalModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public async Task OnGetAsync()
        {
            var employeeDto = await _employeeAppService.GetAsync(Id);
            Employee = ObjectMapper.Map<EmployeeDto, EmployeeCreateUpdateDto>(employeeDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeAppService.UpdateAsync(Id, Employee);
            return NoContent();
        }
    }
}
