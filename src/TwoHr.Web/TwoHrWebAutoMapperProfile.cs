using AutoMapper;
using TwoHr.Employees;

namespace TwoHr.Web;

public class TwoHrWebAutoMapperProfile : Profile
{
    public TwoHrWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<EmployeeDto, EmployeeCreateUpdateDto>();
    }
}
