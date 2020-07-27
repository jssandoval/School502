using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using backend.Core.DTOs;
using backend.Core.Entities;

namespace backend.Infrastructure.Mapping
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