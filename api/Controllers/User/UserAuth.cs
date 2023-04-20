using Microsoft.AspNetCore.Mvc;
using ProductManagerAPI.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers.User
{
    public partial class UserController
    {
        [HttpPost("Auth/Register")]
        [SwaggerOperation("add a new user", Tags = new[] { "User Auth" })]
        public void Register() { }

        [HttpPost("Auth/Login")]
        [SwaggerOperation("user login", Tags = new[] { "User Auth" })]
        public void Login() { }

        [HttpGet("Auth/RefreshToken")]
        [SwaggerOperation("get a new JWT token", Tags = new[] { "User Auth" })]
        public void RefreshToken() { }
    }
}
