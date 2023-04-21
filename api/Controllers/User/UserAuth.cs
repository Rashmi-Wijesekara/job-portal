using api.Dtos;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;

namespace api.Controllers.User
{
    public partial class UserController
    {
        [HttpPost("Auth/Register")]
        [SwaggerOperation("add a new user", Tags = new[] { "User Auth" })]
        public IActionResult Register(ForRegistrationDto userForRegistration)
        {
            //check password
            if (userForRegistration.Password != userForRegistration.PasswordConfirm)
            {
                return BadRequest("Mismatched passwords");
            }

            //check email
            string sqlCheckUserExist = "SELECT Email FROM PortalSchema.Users WHERE Email = @Email";
            IEnumerable<string> existingUsers = _dapper.LoadData<string>(sqlCheckUserExist, new { userForRegistration.Email });
            if (existingUsers.Any())
            {
                return BadRequest("Email is already taken");
            }

            //check valid location id
            string sqlCheckValidLocationId = "SELECT LocationId FROM PortalSchema.Locations WHERE LocationId = @LocationId";
            IEnumerable<int> locationValidity = _dapper.LoadData<int>(sqlCheckValidLocationId, new { userForRegistration.LocationId });
            if (!locationValidity.Any())
            {
                return BadRequest("Invalid location id");
            }

            //set password hash & salt
            byte[] passwordSalt = new byte[128 / 8];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(passwordSalt);
            }
            byte[] passwordHash = _authHelper.GetPasswordHash(userForRegistration.Password, passwordSalt);

            string sqlAddUser = @"INSERT INTO PortalSchema.Users (
                [FirstName],
                [LastName],
                [Email],
                [PasswordHash],
                [PasswordSalt],
                [Cv],
                [CoverLetter],
                [LocationId]) VALUES (
                @FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @Cv, @CoverLetter, @LocationId)";

            var paraSqlAddUser = new
            {
                userForRegistration.FirstName,
                userForRegistration.LastName,
                userForRegistration.Email,
                passwordHash,
                passwordSalt,
                userForRegistration.Cv,
                userForRegistration.CoverLetter,
                userForRegistration.LocationId
            };

            bool successAddUser = _dapper.ExecuteSqlWithParameters(sqlAddUser, paraSqlAddUser);
            if (!successAddUser)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        [HttpPost("Auth/Login")]
        [SwaggerOperation("user login", Tags = new[] { "User Auth" })]
        public void Login() { }

        [HttpGet("Auth/RefreshToken")]
        [SwaggerOperation("get a new JWT token", Tags = new[] { "User Auth" })]
        public void RefreshToken() { }
    }
}
