using Business.Commands.ImageCommand;
using Business.Constants;
using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.ImageCommandHandlers
{
    public class ImageSaveCommandHandler : IRequestHandler<ImageSaveCommand, IDataResult<ImageSaveCommandResponse>>
    {
        public async Task<IDataResult<ImageSaveCommandResponse>> Handle(ImageSaveCommand request, CancellationToken cancellationToken)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.ImageFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "../ECommerceAPI/wwwroot/Images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(stream);
            }

            ImageSaveCommandResponse result = new() 
            {
                ImagePath = "https://localhost:44355/Images/" + fileName
            };
            return new SuccessDataResult<ImageSaveCommandResponse>(result, Messages.SavedImageAndSentThePath);
        }
    }
}
