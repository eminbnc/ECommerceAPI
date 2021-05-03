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
    public class GetProductsBySubCategoryQueryHandler : IRequestHandler<GetProductsBySubCategoryQuery, IDataResult<List<GetProductQueryResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductDal _productDal;
        public GetProductsBySubCategoryQueryHandler(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetProductQueryResponse>>> Handle(GetProductsBySubCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = await _productDal.GetAll(p => p.SubCategoryId == request.SubCategoryId);
            if (response .Count>0) return new SuccessDataResult<List<GetProductQueryResponse>>
                    (_mapper.Map<List<GetProductQueryResponse>>(response), Messages.ProductList);
            return new ErrorDataResult<List<GetProductQueryResponse>>(null, Messages.ProductsNotFound);
        }
    }
}
