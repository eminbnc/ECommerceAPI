using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.ProductQueries
{
    public class GetProductsByCategoryWithSubCategoryQuery:IRequest<IDataResult<List<GetProductQueryResponse>>>
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public GetProductsByCategoryWithSubCategoryQuery(int categoryId,int subCategoryId)
        {
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
        }
    }
}
