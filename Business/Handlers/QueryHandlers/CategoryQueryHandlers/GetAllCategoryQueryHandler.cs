using AutoMapper;
using Business.Constants;
using Business.Queries.CategoryQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.CategoryQueryHandlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IDataResult<List<Category>>>
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<Category>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryDal.GetAll();
            if (result!=null) return new SuccessDataResult<List<Category>>(result, Messages.CategoryList);
            return new ErrorDataResult<List<Category>>(Messages.CategoryNotFount);
        }
    }
}
