using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.Request;
using MediatR;

namespace Business.Commands.UserCommands
{
    public class UserForLoginCommand:IRequest<IDataResult<AccessToken>>
    {
        public UserForLoginRequest _userForLoginRequest  { get; set; }

        public UserForLoginCommand(UserForLoginRequest userForLoginRequest)
        {
            _userForLoginRequest = userForLoginRequest;
        }
    }
}
