using AutoMapper;
using Business.BusinessAspects.Autofac;
using Business.Commands.CartCommand;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.CartCommandHandler
{
    public class AddProductToCartCommandHandler : IRequestHandler<UpdateProductToCartCommand, IResult>
    {
        ICartDal _cartDal;
        IMapper _mapper;
        public AddProductToCartCommandHandler(ICartDal cartDal,IMapper mapper)
        {
            _cartDal = cartDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(CartAddRequestValidator),Priority =2)]
        [SecuredOperation("admin,storeowner,user", Priority = 1)]
        public async Task<IResult> Handle(UpdateProductToCartCommand request, CancellationToken cancellationToken)
        {
            var result =await _cartDal.Get(p => p.UserId == request._cartAddRequest.UserId && p.ProductId == request._cartAddRequest.ProductId);
            if (result == null) await _cartDal.Add(_mapper.Map<Cart>(request._cartAddRequest));
            else
            {
                result.Quantity += 1;
                await _cartDal.Update(result);
            }
            return new SuccessResult(Messages.AddToCartSuccessful);
        }
    }
}
