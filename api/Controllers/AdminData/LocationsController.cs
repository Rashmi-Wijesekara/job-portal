using api.Data;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers.AdminData
{
    [ApiController]
    [Route("Locations")]
    public class LocationsController : ControllerBase
    {
        DataContextDapper _dapper;
        public LocationsController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("")]
        [SwaggerOperation("Get all locations list")]
        public void GetAllLocations()
        {

        }

        [HttpGet("{locationId}")]
        [SwaggerOperation("Get location name by id")]
        public void GetLocationById()
        {

        }
    }
}
