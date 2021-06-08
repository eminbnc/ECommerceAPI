using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.ProductQueries
{
    public class GetByUnitPriceQuery : IRequest<IDataResult<List<GetProductQueryResponse>>>
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public GetByUnitPriceQuery(decimal minPrice, decimal maxPrice)
        {
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
    }
}
