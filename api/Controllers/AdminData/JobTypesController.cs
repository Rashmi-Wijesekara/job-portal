using api.Data;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers.AdminData
{
    [ApiController]
    [Route("JobTypes")]
    public class JobTypesController : ControllerBase
    {
        DataContextDapper _dapper;
        public JobTypesController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("")]
        [SwaggerOperation("get a list of all job types")]
        public void GetAllJobTypes()
        {

        }

        [HttpGet("{JobTypeId}")]
        [SwaggerOperation("get job type by id")]
        public void GetJobTypeById()
        {

        }
    }
}
