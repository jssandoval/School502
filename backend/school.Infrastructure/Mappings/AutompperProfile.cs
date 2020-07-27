using AutoMapper;
using school.Core.DTOs;
using school.Core.Entities;

namespace school.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>();
        }
    }
}