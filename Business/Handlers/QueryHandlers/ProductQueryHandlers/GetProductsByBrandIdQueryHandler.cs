using AutoMapper;
using Business.Constants;
using Business.Queries.ProductQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.ProductQueryHandlers
{
    public class GetProductsByBrandIdQueryHandler : IRequestHandler<GetProductsByBrandIdQuery, IDataResult<List<GetProductQueryResponse>>>
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public GetProductsByBrandIdQueryHandler(IMapper mapper,IProductDal productDal)
        {
            _mapper = mapper;
            _productDal=productDal;
        }

        public async Task<IDataResult<List<GetProductQueryResponse>>> Handle(GetProductsByBrandIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _productDal.GetAll(p => p.BrandId == request.BrandId);
            if (response != null) return new SuccessDataResult<List<GetProductQueryResponse>>
                       (_mapper.Map<List<GetProductQueryResponse>>(response), Messages.ProductListedByBrand);
            return new ErrorDataResult<List<GetProductQueryResponse>>(Messages.ProductNotFound);
        }
    }
}
