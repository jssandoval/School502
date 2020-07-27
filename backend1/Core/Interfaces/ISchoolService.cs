using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Core.CustomEntities;
using backend.Core.Entities;
using backend.Core.QueryFilters;

namespace backend.Core.Services
{
    public interface ISchoolService
    {
        PagedList<School> GetSchools(SchoolQueryFilter filters);
        Task<School> GetSchool(string id);
        Task InsertSchool(School school);
        Task<bool> UpdateSchool(School school);
        Task<bool> DeleteSchool(string id);
    }
}