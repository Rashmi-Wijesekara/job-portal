using Microsoft.AspNetCore.Mvc;
using ProductManagerAPI.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers.User
{
    [ApiController]
    //[Route("User")]
    //[SwaggerTag("User")]
    public partial class UserController : ControllerBase
    {
        DataContextDapper _dapper;
        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("test")]
        [ApiExplorerSettings(IgnoreApi = true)]
        //[SwaggerOperation(Tags = new[] { "User testing" })]
        public DateTime TestConnection()
        {
            return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
        }

        [HttpGet("")]
        [SwaggerOperation("Get all users")]
        public void GetAllUsers() { }


    }
}
