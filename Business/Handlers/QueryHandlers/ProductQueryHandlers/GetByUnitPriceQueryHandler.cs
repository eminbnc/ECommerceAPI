using AutoMapper;
using Business.Constants;
using Business.Queries.ProductQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.ProductQueryHandlers
{
    public class GetByUnitPriceQueryHandler : IRequestHandler<GetByUnitPriceQuery, IDataResult<List<GetProductQueryResponse>>>
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public GetByUnitPriceQueryHandler(IMapper mapper,IProductDal productDal)
        {
            _mapper = mapper;
            _productDal = productDal;
        }

        public async Task<IDataResult<List<GetProductQueryResponse>>> Handle(GetByUnitPriceQuery request, CancellationToken cancellationToken)
        {
            if (request.MinPrice > request.MaxPrice)
            {
                decimal tempPrice = request.MaxPrice;
                request.MaxPrice = request.MinPrice;
                request.MinPrice = tempPrice;
            }
            
            var response = await _productDal.GetAll(
                p => p.UnitPrice >= request.MinPrice && p.UnitPrice <= request.MaxPrice);
            if(response!=null) return new SuccessDataResult<List<GetProductQueryResponse>>
                    (_mapper.Map<List<GetProductQueryResponse>>(response), Messages.ProductList);
            return new ErrorDataResult<List<GetProductQueryResponse>>(null, Messages.ProductsNotFound);
        }
    }
}
