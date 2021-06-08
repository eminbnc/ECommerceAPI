using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.BrandQueries
{
    public class GetBrandsQuery:IRequest<IDataResult<List<Brand>>>
    {
    }
}
