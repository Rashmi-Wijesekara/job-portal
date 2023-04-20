using Microsoft.AspNetCore.Mvc;
using ProductManagerAPI.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers.User
{
    public partial class UserController
    {
        [HttpPatch("Profile")]
        [SwaggerOperation("add other details for the new user", Tags = new[] { "User Profile" })]
        public void AddProfileData() { }

        [HttpPatch("Profile/Edit")]
        [SwaggerOperation("edit User Profile details", Tags = new[] { "User Profile" })]
        public void EditProfileData() { }

        [HttpPost("Profile/PasswordReset")]
        [SwaggerOperation("reset password", Tags = new[] { "User Profile" })]
        public void PasswordReset() { }
    }
}
