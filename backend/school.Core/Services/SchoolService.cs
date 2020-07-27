using System;
using System.Linq;
using System.Threading.Tasks;
using school.Core.CustomEntities;
using school.Core.Entities;
using school.Core.Exceptions;
using school.Core.Interfaces;
using school.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace school.Core.Services
{
    public class SchoolService : ISchoolService
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IRepository<School> _schoolRepository;
        private readonly IUnitOfWork _schoolRepository;
        private readonly PaginationOptions _paginationOptions;

        public SchoolService(IUnitOfWork schoolRepository, IOptions<PaginationOptions> options)
        {
            //IRepository<School> schoolRepository
            _schoolRepository = schoolRepository;
            _paginationOptions = options.Value;
        }

        public async Task<School> GetSchool(string id)
        {
            //return await _schoolRepositor.GetById(id); //.GetSchool(id);
            return await _schoolRepository.SchoolRepository.GetById(id);
        }

        public PagedList<School> GetSchools(SchoolQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            //return _schoolRepository.GetAll(); //.GetSchools();
            var schools = _schoolRepository.SchoolRepository.GetAll().ToList();
            //filtros
            if (!String.IsNullOrEmpty(filters.Id) )
            {
                schools = schools.Where(x => x.Id.ToLower().Contains(filters.Id)).ToList();
            }
            if (!String.IsNullOrEmpty(filters.Name))
            {
                schools = schools.Where(x => x.Name.ToLower().Contains(filters.Name)).ToList();
            }

            //paginacion

            var pageSchools = PagedList<School>.Create(schools, filters.PageNumber, filters.PageSize);
            return pageSchools;
        }

        public async Task InsertSchool(School school)
        {
            //await _schoolRepository.Add(school);
            await _schoolRepository.SchoolRepository.Add(school);
        }

        public async Task<bool> UpdateSchool(School school)
        {
            //var existingPost = await _schoolRepository.GetById(school.Id);
            var existingSchool = await _schoolRepository.SchoolRepository.GetById(school.Id);
            if (existingSchool != null)
            {
                existingSchool.Name = school.Name;
                existingSchool.Description = school.Description;
                existingSchool.Logo = school.Logo;
                existingSchool.Status = school.Status;
                //await _schoolRepository.SaveChangesAsync();
                //return await _schoolRepository.Update(existingPost);
                return await _schoolRepository.SchoolRepository.Update(existingSchool);
            }
            else
            {
                throw new BusinessException("NO update");
                //return false;
            }
            //return await _schoolRepository.Update(school);
            //return await _schoolRepository.UpdateSchool(school);
        }

        public async Task<bool> DeleteSchool(string id)
        {
            //var existingPost = await _schoolRepository.GetById(id);
            var existingSchool = await _schoolRepository.SchoolRepository.GetById(id);
            if (existingSchool != null)
            {
                //return await _schoolRepository.Delete(id); //.DeleteSchool(id);
                return await _schoolRepository.SchoolRepository.Delete(id);
            }
            else
            {
                return false;
            }
        }

    }
}