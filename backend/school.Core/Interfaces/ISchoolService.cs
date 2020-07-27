using System.Threading.Tasks;
using school.Core.CustomEntities;
using school.Core.Entities;
using school.Core.QueryFilters;

namespace school.Core.Services
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