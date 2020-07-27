using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using school.Core.CustomEntities;
using school.Core.DTOs;
using school.Core.Entities;
using school.Core.QueryFilters;
using school.Core.Services;
using school.Infrastructure.Interfaces;
using school.Responses;

namespace school.Controllers
{
    [Authorize] // (Roles = "Administrador")] //nameof(RoleType,xx,yy)]
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public SchoolController(ISchoolService schoolRepository, IMapper mapper, IUriService uriService)
        {
            _schoolService =  schoolRepository;
            _mapper = mapper;
            _uriService = uriService;
        } 

        /// <summary>
        /// Retrive all Schools
        /// </summary>
        /// <param name="filters">filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetSchools))]
        [ProducesResponseType((int)HttpStatusCode.OK,Type = typeof(ApiResponse<IEnumerable<SchoolDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<SchoolDto>>))]
        public IActionResult GetSchools([FromQuery]SchoolQueryFilter filters)
        {
            // Console.Write("al api");
            //var schools = await _schoolService.GetSchools();
            //var schoolDtos = _mapper.Map<IEnumerable<SchoolDto>>(schools);
            //var response = new ApiResponse<IEnumerable<SchoolDto>>(schoolDto/s);
            //var schoolDto = _mapper.Map<IEquatable<SchoolDto>>(school);
            //var schoolDto = school.AsQueryable<School>().Select( x => new SchoolDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Logo = x.Logo,
            //    Status = x.Status
            //});
            //await Task.Delay(1);
            var schools =  _schoolService.GetSchools(filters);
            var schoolDtos = _mapper.Map<IEnumerable<SchoolDto>>(schools);

            var metadata = new Metadata
            {
                TotalCount = schools.TotalCount,
                PageSize = schools.PageSize,
                CurrentPage = schools.CurrentPage,
                TotalPages = schools.TotalPages,
                HasNextPage = schools.HasNextPage,
                HasPreviousPage = schools.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetSchools))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetSchools))).ToString()
            };

            var response = new ApiResponse<IEnumerable<SchoolDto>>(schoolDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            //var response = new ApiResponse<IEnumerable<SchoolDto>>(schoolDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchool(string id){
            // Console.Write("al api");
            var school = await _schoolService.GetSchool(id);
            var schoolDto = _mapper.Map<SchoolDto>(school);
            var response = new ApiResponse<SchoolDto>(schoolDto);
            // var schoolDto = new SchoolDto 
            //{
            //     Id = school.Id,
            //     Name = school.Name,
            //     Description = school.Description,
            //     Logo = school.Logo,
            //     Status = school.Status
            //}; 
            // Console.Write(school);

            return Ok(response);
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
            await _schoolService.InsertSchool(school);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(string id, SchoolDto schoolDto)
        {
            var school = _mapper.Map<School>(schoolDto);
            school.Id = id;
            var result = await _schoolService.UpdateSchool(school);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(string id)
        {
            var result = await _schoolService.DeleteSchool(id);
            var response = new ApiResponse<bool>(result); 
            return Ok(response);
        }
    }
}