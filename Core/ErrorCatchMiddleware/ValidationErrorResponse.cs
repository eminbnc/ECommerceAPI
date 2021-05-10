using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.ErrorCatchMiddleware
{
    public class ValidationErrorResponse:ErrorResponse
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
