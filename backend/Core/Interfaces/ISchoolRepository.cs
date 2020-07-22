using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Core.Entities;

namespace backend.Core.Interfaces
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetSchools();
        Task<School> GetSchool(string id);
        Task InsertSchool(School school);
    }
}