using DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Core.Utilities.Results;
using Business.Constants;
using Business.Queries.ProductQueries;
using Entities.DTOs.Response;
using Core.Aspect.Autofac.Caching;

namespace Business.Handlers.QueryHandlers.ProductQueryHandlers
{
    public class GetAllProductsQueryHandler:IRequestHandler<GetAllProductsQuery, IDataResult<List<GetProductQueryResponse>>>
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler( IMapper mapper,IProductDal productDal)
        {
           _productDal = productDal;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<IDataResult<List<GetProductQueryResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        { 
            var response = await _productDal.GetAll();
            if (response.Count > 0)  return new SuccessDataResult<List<GetProductQueryResponse>>
                    ( _mapper.Map<List<GetProductQueryResponse>>(response),Messages.ProductList);
            return new ErrorDataResult<List<GetProductQueryResponse>>(null, Messages.ProductsNotFound);
        }

       
    }
}
