using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.SubCategoryQueries
{
    public class GetAllSubCategoriesQuery:IRequest<IDataResult<List<SubCategory>>>
    {
    }
}
