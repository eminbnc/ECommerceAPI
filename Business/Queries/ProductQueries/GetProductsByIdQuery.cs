using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;

namespace Business.Queries.ProductQueries
{
    public class GetProductsByIdQuery : IRequest<IDataResult<GetProductQueryResponse>>
    {
        public int ProductId { get; set; }
        public GetProductsByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
