using Newtonsoft.Json;

namespace Core.ErrorCatchMiddleware
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
