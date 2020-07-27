using System;
using school.Core.QueryFilters;

namespace school.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(SchoolQueryFilter filter, string actionUrl);
    }
}
