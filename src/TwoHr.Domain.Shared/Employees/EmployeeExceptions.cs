using System;
using Volo.Abp;

namespace TwoHr.Employees
{    
    public class EmployeeAlreadyExistsException : BusinessException
    {
        public EmployeeAlreadyExistsException(string name)
            : base(TwoHrDomainErrorCodes.EmployeeAlreadyExists)
        {
            WithData("name", name);
        }
    }

    public class EmployeeNameInvalidException : BusinessException
    {
        public EmployeeNameInvalidException(string name) : base(TwoHrDomainErrorCodes.EmployeeNameInvalid)
        {
            WithData("name", name);
        }
    }

    public class EmployeeBirthDateInvalidException : BusinessException
    {
        public EmployeeBirthDateInvalidException(DateTime birthDate) : base(TwoHrDomainErrorCodes.EmployeeBirthDateInvalid)
        {
            WithData("birthDate", birthDate);
        }
    }

    public class EmployeeSalaryInvalidException : BusinessException
    {
        public EmployeeSalaryInvalidException(double salary) : base(TwoHrDomainErrorCodes.EmployeeSalaryInvalid)
        {
            WithData("salary", salary);
        }
    }
}
