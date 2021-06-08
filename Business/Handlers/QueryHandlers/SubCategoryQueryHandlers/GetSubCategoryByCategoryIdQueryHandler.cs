using Business.Constants;
using Business.Queries.SubCategoryQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.SubCategoryQueryHandlers
{
    public class GetSubCategoryByCategoryIdQueryHandler : IRequestHandler<GetSubCategoryByCategoryIdQuery, IDataResult<List<SubCategory>>>
    {
        private readonly ISubCategoryDal _subCategoryDal;

        public GetSubCategoryByCategoryIdQueryHandler(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public async Task<IDataResult<List<SubCategory>>> Handle(GetSubCategoryByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _subCategoryDal.GetAll(s => s.CategoryId == request.CategoryId);
            if (response != null) return new SuccessDataResult<List<SubCategory>>(response, Messages.SubCategoryListed);
            return new ErrorDataResult<List<SubCategory>>(Messages.SubCategoryNotFount);
        }
    }
}
