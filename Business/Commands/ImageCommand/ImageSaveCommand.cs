using Core.Utilities.Results;
using Entities.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commands.ImageCommand
{
    public class ImageSaveCommand:IRequest<IDataResult<ImageSaveCommandResponse>>
    {
        public IFormFile ImageFile { get; }

        public ImageSaveCommand(IFormFile imageFile)
        {
            ImageFile = imageFile;
        }
    }
}
