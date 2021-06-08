using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.ProductQueries
{
    public class GetProductsByBrandIdQuery:IRequest<IDataResult<List<GetProductQueryResponse>>>
    {
        public int BrandId { get; set; }

        public GetProductsByBrandIdQuery(int brandId)
        {
            BrandId = brandId;
        }
    }
}
