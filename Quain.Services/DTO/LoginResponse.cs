namespace Quain.Services.DTO
{
    public class LoginResponseDTO
    {
        public string? Message { get; set; }
        public string? UserName { get; set; }
        public string? Token { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
