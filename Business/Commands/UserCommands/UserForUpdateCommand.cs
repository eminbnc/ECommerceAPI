using Core.Utilities.Results;
using Entities.DTOs.Request;
using Entities.DTOs.Response;
using MediatR;

namespace Business.Commands.UserCommands
{
    public class UserForUpdateCommand:IRequest<IDataResult<GetUserResponse>>
    {
        public UserUpdateRequest _userUpdateRequest { get; set; }

        public UserForUpdateCommand(UserUpdateRequest userUpdateRequest)
        {
            _userUpdateRequest = userUpdateRequest;
        }
    }
}
