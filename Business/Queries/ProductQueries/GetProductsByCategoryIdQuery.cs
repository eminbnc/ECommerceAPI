using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.ProductQueries
{
    public class GetProductsByCategoryIdQuery:IRequest<IDataResult<List<GetProductQueryResponse>>>
    {
        public int CategoryId { get; set; }

        public GetProductsByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
