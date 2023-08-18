namespace Quain.Exceptions.Response
{
    public class ExceptionResponse
    {
        public int Status { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}