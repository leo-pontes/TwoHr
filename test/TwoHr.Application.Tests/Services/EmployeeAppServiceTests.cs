using Shouldly;
using System;
using System.Threading.Tasks;
using TwoHr.Employees;
using Xunit;

namespace TwoHr.Services;

public class EmployeeAppServiceTests : TwoHrApplicationTestBase
{
    private readonly IEmployeeAppService _employeeAppService;

    public EmployeeAppServiceTests()
    {
        _employeeAppService = GetRequiredService<IEmployeeAppService>();
    }

    [Fact]
    public async Task CreateAsync_Success()
    {
        //Act
        var result = await _employeeAppService.CreateAsync(
            new EmployeeCreateUpdateDto()
            {
                Name = "Unit Test",
                Salary = 5000,
                Active = true,
                BirthDate = DateTime.Now.AddYears(-25)
            });

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe("Unit Test");
    }
}
