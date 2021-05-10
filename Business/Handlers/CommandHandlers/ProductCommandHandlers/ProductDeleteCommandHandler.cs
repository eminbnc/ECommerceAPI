using Business.BusinessAuthAspects.Autofac;
using Business.Commands.ProductCommands;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.ProductCommandHandlers
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, IResult>
    {
        IProductDal _productDal;
        public ProductDeleteCommandHandler(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [CacheRemoveAspect("GetAllProductsQuery", Priority = 2)]
        [SecuredOperation("admin,storeowner", Priority = 1)]
        public async Task<IResult> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var checkIfProductExist =await _productDal.Get(p => p.Id == request.ProductId);
            if (checkIfProductExist != null)
            {
                await _productDal.Delete(checkIfProductExist);
                return new SuccessResult(Messages.ProductDeletedSuccessfully);
            }
            return new ErrorResult(Messages.ProductNotFound);
        }
    }
}
