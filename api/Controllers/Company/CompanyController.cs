using Microsoft.AspNetCore.Mvc;
using api.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers.Company
{
    [ApiController]
    [Route("Company")]
    public partial class CompanyController : ControllerBase
    {
        [HttpPost("Auth/Register")]
        [SwaggerOperation("add a new company")]
        public void Register() { }

        [HttpPost("Auth/Login")]
        [SwaggerOperation("company login")]
        public void Login() { }

        [HttpGet("Auth/RefreshToken")]
        [SwaggerOperation("get a new JWT token")]
        public void RefreshToken() { }
    }
}
