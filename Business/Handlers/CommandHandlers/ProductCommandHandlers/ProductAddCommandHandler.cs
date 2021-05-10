using AutoMapper;
using Business.BusinessAuthAspects.Autofac;
using Business.Commands.ProductCommands;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.ProductsCommandHandlers
{

    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, IResult>
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
      
        public ProductAddCommandHandler(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        
        [SecuredOperation("admin,storeowner", Priority = 1)]
        [CacheRemoveAspect("GetAllProductsQuery", Priority = 3)]
        [ValidationAspect(typeof(ProductAddRequestValidator),Priority =2)]
        public async Task<IResult> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request._product);
            await _productDal.Add(product);
            //await _productDal.SaveChangesAsync();
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
