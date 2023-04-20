namespace api.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Cv { get; set; }
        public string CoverLetter { get; set; }
        public int LocationId { get; set; }

        public User()
        {
            FirstName ??= "";
            LastName ??= "";
            PasswordHash ??= "";
            PasswordSalt ??= "";
            Email ??= "";
            Cv ??= "";
            CoverLetter ??= "";
        }
    }
}
