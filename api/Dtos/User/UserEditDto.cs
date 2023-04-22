namespace api.Dtos.User
{
    public class UserEditDto
    {
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public IFormFile? Cv { get; set; }
        public IFormFile? CoverLetter { get; set; }
        public int? LocationId { get; set; }
    }
}
