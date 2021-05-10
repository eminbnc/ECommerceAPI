using Business.BusinessAuthAspects.Autofac;
using Business.Commands.CartCommand;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.CartCommandHandlers
{
    public class UpdateProductInCartCommandHandler : IRequestHandler<UpdateProductInCartCommand, IResult>
    {
        private readonly ICartDal _cartDal;

        public UpdateProductInCartCommandHandler(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        [SecuredOperation("admin,storeowner,user", Priority = 1)]
        [ValidationAspect(typeof(UpdateCartValidator),Priority =2)]
        public async Task<IResult> Handle(UpdateProductInCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartDal.Get(p => p.Id == request._cart.Id);
            if (result == null) return new ErrorResult(Messages.ItemsNotInTheCart);
            await _cartDal.Update(request._cart);
            return new SuccessResult(Messages.CarUpdateSuccessful);
        }
    }
}
