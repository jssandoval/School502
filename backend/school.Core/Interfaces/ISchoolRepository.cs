using System.Collections.Generic;
using System.Threading.Tasks;
using school.Core.Entities;

namespace school.Core.Interfaces
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetSchools();
        Task<School> GetSchool(string id);
        Task InsertSchool(School school);
        Task<bool> UpdateSchool(School school);
        Task<bool> DeleteSchool(string id);
    }
}