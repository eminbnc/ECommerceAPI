using Business.Commands.UserCommands;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.UserCommandHandler
{
    public class UserForRegisterCommandHandler : IRequestHandler<UserForRegisterCommand, IResult>
    {
        IUserDal _userDal;

        public UserForRegisterCommandHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserForRegisterValidator), Priority = 1)]
        public async Task<IResult> Handle(UserForRegisterCommand request, CancellationToken cancellationToken)
        {
            var checkIfEmail = await _userDal.Get(p => p.Email == request._userForRegisterRequest.Email);
            if (checkIfEmail != null) return new ErrorResult(Messages.EmailAlreadyExist);

            byte[] passwordHash, paswordSalt;
            HashingHelper.CreatePasswordHash(request._userForRegisterRequest.Password,
                out passwordHash, out paswordSalt);
            var newUser = new User
            {
                Email = request._userForRegisterRequest.Email,
                Telephone = request._userForRegisterRequest.Telephone,
                Status = true,
                FirstName = request._userForRegisterRequest.FirstName,
                LastName = request._userForRegisterRequest.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = paswordSalt
            };
           await _userDal.Add(newUser);
           return new SuccessResult(Messages.RegistrationIsSuccessful);
        }
    }
}
