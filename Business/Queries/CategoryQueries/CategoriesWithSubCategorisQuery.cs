using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.CategoryQueries
{
    public class CategoriesWithSubCategorisQuery:IRequest<IDataResult<List<CategoriesWithSubCategoriesResponse>>>
    {
    }
}
