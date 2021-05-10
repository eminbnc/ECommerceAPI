using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.CartQueries
{
    public class GetItemsInCartQuery:IRequest<IDataResult<List<GetItemsInCartResponse>>>
    {
        public int UserId { get; set; }

        public GetItemsInCartQuery(int userId)
        {
            UserId = userId;
        }
    }
}
