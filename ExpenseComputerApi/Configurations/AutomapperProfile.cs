using AutoMapper;
using ExpenseComputer.Dto.Request;
using ExpenseComputer.Entity;

namespace ExpenseComputer.Api.Configurations
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Expense, ExpenseRequestDto>().ReverseMap();
        }
    }
}
