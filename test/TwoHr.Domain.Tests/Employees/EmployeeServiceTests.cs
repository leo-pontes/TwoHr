using NSubstitute;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
namespace TwoHr.Employees;

public class EmployeeServiceTests : TwoHrDomainTestBase
{
    private readonly EmployeeService _employeeService;

    private Employee employeeSuccess;    

    public EmployeeServiceTests()
    {        
        _employeeService = GetRequiredService<EmployeeService>();

        employeeSuccess = new Employee(Guid.NewGuid(), "1234", true, DateTime.Now.AddYears(-20), 2500);        
    }

    [Fact]
    public async Task CreateAsync_Sucess()
    {
        //Act
        var result = await _employeeService.CreateAsync(employeeSuccess.Name, employeeSuccess.Active, employeeSuccess.BirthDate, employeeSuccess.Salary);

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe(employeeSuccess.Name);
    }

    [Fact]
    public async Task CreateAsync_Error_AlreadyExist()
    {                        
        var fakeRepo = Substitute.For<IEmployeeRepository>();
        fakeRepo.FindByNameAsync(employeeSuccess.Name).Returns(employeeSuccess);

        var service = new EmployeeService(fakeRepo);

        //Act
        try
        {
            var result = await service.CreateAsync(
                employeeSuccess.Name,
                employeeSuccess.Active,
                employeeSuccess.BirthDate,
                employeeSuccess.Salary);

            //Assert
            Assert.True(false);
        }
        catch (Exception ex)
        {
            //Assert
            Assert.Equal(typeof(EmployeeAlreadyExistsException), ex.GetType());
        }        
    }
}
