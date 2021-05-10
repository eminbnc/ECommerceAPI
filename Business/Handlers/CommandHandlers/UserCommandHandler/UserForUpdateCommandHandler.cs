using AutoMapper;
using Business.BusinessAuthAspects.Autofac;
using Business.Commands.UserCommands;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.UserCommandHandler
{
    public class UserForUpdateCommandHandler : IRequestHandler<UserForUpdateCommand, IDataResult<GetUserResponse>>
    {
        private readonly IUserDal _userDal;
       private readonly IMapper _mapper;
        public UserForUpdateCommandHandler(IUserDal userDal,IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin,storeowner,user",Priority =1)]
        public async Task<IDataResult<GetUserResponse>> Handle(UserForUpdateCommand request, CancellationToken cancellationToken)
        {
            var userToCheck = await _userDal.Get(p => p.Id == request._userUpdateRequest.Id);
            if (userToCheck == null) return new ErrorDataResult<GetUserResponse>(Messages.UserNotFound);
            var updatedUser = _mapper.Map<User>(request._userUpdateRequest);
            updatedUser.PasswordHash = userToCheck.PasswordHash;
            updatedUser.PasswordSalt = userToCheck.PasswordSalt;
            updatedUser.Email = userToCheck.Email;
            await _userDal.Update(updatedUser);
            return new SuccessDataResult<GetUserResponse>(_mapper.Map<GetUserResponse>(updatedUser),Messages.UserUpdatedSuccessful);
        }
    }
}
