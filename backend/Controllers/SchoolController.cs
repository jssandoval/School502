using System;
using System.Threading.Tasks;
using backend.Core.Interfaces;
using backend.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using backend.Core.Entities;
using MongoDB.Driver.Linq;
using System.Linq;
using AutoMapper;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;


        public SchoolController(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository =  schoolRepository;
            _mapper = mapper;
        } 

        [HttpGet]
        public async Task<IActionResult> GetSchools(){
            // Console.Write("al api");
            var school = await _schoolRepository.GetSchools();
            var schoolDto = _mapper.Map<IEquatable<SchoolDto>>(school);
            //var schoolDto = school.AsQueryable<School>().Select( x => new SchoolDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Logo = x.Logo,
            //    Status = x.Status
            //});
            return Ok(schoolDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchool(string id){
            // Console.Write("al api");
            var school = await _schoolRepository.GetSchool(id);
            var schoolDto = _mapper.Map<SchoolDto>(school);
           // var schoolDto = new SchoolDto 
           //{
           //     Id = school.Id,
           //     Name = school.Name,
           //     Description = school.Description,
           //     Logo = school.Logo,
           //     Status = school.Status
           //}; 
            // Console.Write(school);
            return Ok(schoolDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostSchool(SchoolDto schoolDto){
            // Console.Write("al api");
            //var school = new School
            //{
            //    Name = schoolDto.Name,
            //    Description = schoolDto.Description,
            //    Logo = schoolDto.Logo,
            //    Status = schoolDto.Status
            //};
            var school = _mapper.Map<School>(schoolDto);
            await _schoolRepository.InsertSchool(school);
            return Ok(schoolDto);
        }
    }    
}