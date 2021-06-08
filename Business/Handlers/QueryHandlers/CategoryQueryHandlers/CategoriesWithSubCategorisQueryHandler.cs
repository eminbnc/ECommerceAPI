using AutoMapper;
using Business.Constants;
using Business.Queries.CategoryQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.Response;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesWithSubCategorisQueryHandler : IRequestHandler<CategoriesWithSubCategorisQuery, IDataResult<List<CategoriesWithSubCategoriesResponse>>>
    {
        private readonly ICategoryDal _categoryDal;

        public CategoriesWithSubCategorisQueryHandler(IMapper mapper,ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IDataResult<List<CategoriesWithSubCategoriesResponse>>> Handle(CategoriesWithSubCategorisQuery request, CancellationToken cancellationToken)
        {
            var response = await _categoryDal.GetCategoriesWithSubCategory();
            if (response != null) return new SuccessDataResult<List<CategoriesWithSubCategoriesResponse>>
                       (response, Messages.CategoriesWithSubCategoriesListed);
            return new ErrorDataResult<List<CategoriesWithSubCategoriesResponse>>(Messages.CategoryNotFount);
        }
    }
}
