namespace api.Dtos
{
    public class ForRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Cv { get; set; }
        public string CoverLetter { get; set; }
        public int LocationId { get; set; }

        public ForRegistrationDto()
        {
            FirstName ??= "";
            LastName ??= "";
            Password ??= "";
            PasswordConfirm ??= "";
            Email ??= "";
            Cv ??= "";
            CoverLetter ??= "";
        }
    }
}
