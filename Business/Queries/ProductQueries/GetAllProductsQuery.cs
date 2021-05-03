using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.ProductQueries
{
    public class GetAllProductsQuery : IRequest<IDataResult<List<GetProductQueryResponse>>>
    {
    }
}
