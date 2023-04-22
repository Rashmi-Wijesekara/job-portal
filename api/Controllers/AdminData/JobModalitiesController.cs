using api.Data;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers.AdminData
{
    [ApiController]
    [Route("JobModalities")]
    public class JobModalitiesController : ControllerBase
    {
        DataContextDapper _dapper;
        public JobModalitiesController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("")]
        [SwaggerOperation("get a list of all the modalities")]
        public void GetAllModalities()
        {

        }

        [HttpGet("{JobModalityId}")]
        [SwaggerOperation("get job modality by id")]
        public void GetModalityById()
        {

        }
    }
}
