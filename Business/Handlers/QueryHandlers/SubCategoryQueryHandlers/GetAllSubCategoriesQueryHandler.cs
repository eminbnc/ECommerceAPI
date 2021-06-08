using Business.Constants;
using Business.Queries.SubCategoryQueries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.SubCategoryQueryHandlers
{
    public class GetAllSubCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesQuery, IDataResult<List<SubCategory>>>
    {
        private readonly ISubCategoryDal _subCategoryDal;

        public GetAllSubCategoriesQueryHandler(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public async Task<IDataResult<List<SubCategory>>> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = await _subCategoryDal.GetAll();
            if (response != null) return new SuccessDataResult<List<SubCategory>>(response, Messages.SubCategoryListed);
            return new ErrorDataResult<List<SubCategory>>(Messages.SubCategoryNotFount);
        }
    }
}
