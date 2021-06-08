using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.CategoryQueries
{
    public class GetAllCategoryQuery:IRequest<IDataResult<List<Category>>>
    {
    }
}
