using AutoMapper;
using Business.Constants;
using Business.Queries.ProductQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.ProductQueryHandlers
{
    public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery,IDataResult<GetProductQueryResponse>>
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public GetProductsByIdQueryHandler(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetProductQueryResponse>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _productDal.Get(p => p.Id == request.ProductId);
            if (response!=null) return new SuccessDataResult<GetProductQueryResponse>( _mapper.Map<GetProductQueryResponse>(response), Messages.ProductReturnedSuccessfully);
            return new ErrorDataResult<GetProductQueryResponse>(null, Messages.ProductNotFound);
        }
    }
}
