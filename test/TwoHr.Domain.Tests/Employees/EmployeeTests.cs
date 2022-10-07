using System;
using Xunit;

namespace TwoHr.Employees
{
    public class EmployeeTests
    {
        [Fact]
        public void Create_Sucess()
        {
            var (nome, active, birthDate, salary) = GetEmployeeDeconstructed();

            //Act            
            var result = new Employee(Guid.NewGuid(), nome, active, birthDate, salary);

            //Assert
            Assert.Equal(result.Name, nome);          
        }

        [Fact]
        public void Create_Error_NameInvalid()
        {
            var (nome, active, birthDate, salary) = GetEmployeeDeconstructed();
            nome = "1";

            //Act
            try
            {
                var result = new Employee(Guid.NewGuid(), nome, active, birthDate, salary);

                Assert.True(false);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(typeof(EmployeeNameInvalidException), ex.GetType());
            }
        }

        [Fact]
        public void Create_Error_BirthDateInvalid()
        {
            var (nome, active, birthDate, salary) = GetEmployeeDeconstructed();
            birthDate = DateTime.Now;

            //Act
            try
            {
                var result = new Employee(Guid.NewGuid(), nome, active, birthDate, salary);

                Assert.True(false);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(typeof(EmployeeBirthDateInvalidException), ex.GetType());
            }
        }

        [Fact]
        public void Create_Error_SalaryInvalid()
        {
            var (nome, active, birthDate, salary) = GetEmployeeDeconstructed();
            salary = 500;

            //Act
            try
            {
                var result = new Employee(Guid.NewGuid(), nome, active, birthDate, salary);

                Assert.True(false);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(typeof(EmployeeSalaryInvalidException), ex.GetType());
            }
        }

        private (string, bool, DateTime, double) GetEmployeeDeconstructed()
        {
            return new Tuple<string, bool, DateTime, double>("Name", true, DateTime.Now.AddYears(-20), 2500).ToValueTuple();
        }
    }
}
