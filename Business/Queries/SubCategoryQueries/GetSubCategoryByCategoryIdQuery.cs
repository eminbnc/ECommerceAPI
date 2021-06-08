using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.SubCategoryQueries
{
    public class GetSubCategoryByCategoryIdQuery:IRequest<IDataResult<List<SubCategory>>>
    {
        public int CategoryId { get; set; }
        public GetSubCategoryByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
