namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
      
        public ErrorDataResult(T data, string message) : base(data, message, false)
        {
        }
        public ErrorDataResult(string message) : base(default, message, false)
        {
        }
    }
}
