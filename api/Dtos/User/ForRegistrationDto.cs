namespace api.Dtos.User
{
    public class ForRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public IFormFile? Cv { get; set; }
        public IFormFile? CoverLetter { get; set; }
        public int LocationId { get; set; }

        public ForRegistrationDto()
        {
            FirstName ??= "";
            LastName ??= "";
            Password ??= "";
            PasswordConfirm ??= "";
            Email ??= "";
        }
    }
}
