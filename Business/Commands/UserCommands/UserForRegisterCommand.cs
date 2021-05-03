using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs.Request;
using MediatR;

namespace Business.Commands.UserCommands
{
    public class UserForRegisterCommand:IRequest<IResult>
    {
        public UserForRegisterRequest _userForRegisterRequest { get; set; }

        public UserForRegisterCommand(UserForRegisterRequest userForRegisterRequest)
        {
            _userForRegisterRequest = userForRegisterRequest;
        }
    }
}
