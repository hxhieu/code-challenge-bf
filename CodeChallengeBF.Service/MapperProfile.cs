using AutoMapper;
using CodeChallengeBF.Data.Entity;
using CodeChallengeBF.Service.Models;

namespace CodeChallengeBF.Service
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Just map by naming convention
            CreateMap<TestFormModel, TestFormEntity>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .ReverseMap();
        }
    }
}
