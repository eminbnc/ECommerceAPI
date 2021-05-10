using Business.Constants;
using Business.Queries.CartQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.CartQueryHandlers
{
    public class GetItemsInCartQueryHandler : IRequestHandler<GetItemsInCartQuery, IDataResult<List<GetItemsInCartResponse>>>
    {
        private readonly ICartDal  _cartDal;

        public GetItemsInCartQueryHandler(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public async Task<IDataResult<List<GetItemsInCartResponse>>> Handle(GetItemsInCartQuery request, CancellationToken cancellationToken)
        {
            var result = await _cartDal.GetItemsInBasket(request.UserId);
            if (result != null) return new SuccessDataResult<List<GetItemsInCartResponse>>(result,
                   Messages.ListinItemsInCartSuccessful);
            return new ErrorDataResult<List<GetItemsInCartResponse>>(Messages.ProductInCartNotFound);

        }
    }
}
