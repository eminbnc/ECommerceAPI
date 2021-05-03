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
    public class GetProductsByCategoryWithSubCategoryQueryHandler : IRequestHandler<GetProductsByCategoryWithSubCategoryQuery, IDataResult<List<GetProductQueryResponse>>>
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public GetProductsByCategoryWithSubCategoryQueryHandler(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetProductQueryResponse>>> Handle(GetProductsByCategoryWithSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = await _productDal.GetProductsByCategoryWithSubCategory(request.CategoryId, request.SubCategoryId);
            if (response.Count > 0) return new SuccessDataResult<List<GetProductQueryResponse>>(response, Messages.ProductList);
            return new ErrorDataResult<List<GetProductQueryResponse>>(null, Messages.ProductsNotFound);
        }
    }
}
