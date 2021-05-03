using Business.Commands.ProductCommands;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.ProductCommandHandlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, IResult>
    {
        private readonly IProductDal _productDal;
        public ProductUpdateCommandHandler(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheRemoveAspect("GetAllProductsQuery", Priority = 2)]
        [ValidationAspect(typeof(ProductValidator),Priority =1)]
        public async Task<IResult> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var checkIfProductExist = await _productDal.Get(p => p.Id == request._product.Id);
            if (checkIfProductExist != null)
            {
                await _productDal.Update(request._product);
                return new SuccessResult(Messages.SuccessfulProductUpdate);
            }
            return new ErrorResult(Messages.ProductNotFound);
        }
    }
}
