using AutoMapper;
using TwoHr.Employees;

namespace TwoHr;

public class TwoHrApplicationAutoMapperProfile : Profile
{
    public TwoHrApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeCreateUpdateDto, Employee>();
    }
}
