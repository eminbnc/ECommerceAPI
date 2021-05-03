using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.ProductQueries
{
    public class GetProductsBySubCategoryQuery:IRequest<IDataResult<List<GetProductQueryResponse>>>
    {
        public int SubCategoryId { get; set; }
        public GetProductsBySubCategoryQuery(int subCategoryId)
        {
            SubCategoryId = subCategoryId;
        }
    }
}
