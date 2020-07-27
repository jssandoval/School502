using System;
using backend.Core.QueryFilters;

namespace backend.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(SchoolQueryFilter filter, string actionUrl);
    }
}
