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
    public class GetProductsByCategoryIdQueryHnadler : IRequestHandler<GetProductsByCategoryIdQuery, IDataResult<List<GetProductQueryResponse>>>
    {
        private readonly IProductDal _productDal;

        public GetProductsByCategoryIdQueryHnadler(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        public async Task<IDataResult<List<GetProductQueryResponse>>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _productDal.GetProductsByCategoryId(request.CategoryId);
            if (response != null) return new SuccessDataResult<List<GetProductQueryResponse>>(
                   _mapper.Map<List<GetProductQueryResponse>>(response), Messages.ProductList);
            return new ErrorDataResult<List<GetProductQueryResponse>>(Messages.ProductNotFound);
        }
    }
}
