using AutoMapper;
using Business.Constants;
using Business.Queries.BrandQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.BrandQueryHandler
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IDataResult<List<Brand>>>
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        public GetBrandsQueryHandler(IBrandDal brandDal,IMapper mapper)
        {
            _mapper = mapper;
            _brandDal = brandDal;
        }

        public async Task<IDataResult<List<Brand>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var result = await _brandDal.GetAll();
            if (result != null) return new SuccessDataResult<List<Brand>>(result, Messages.BrandListSuccessful);
            return new ErrorDataResult<List<Brand>>(Messages.BrandNotFound);
        }
    }
}
