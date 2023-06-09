﻿using Microsoft.AspNetCore.Mvc;
using api.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers.Job
{
    [ApiController]
    [Route("Jobs")]
    public partial class JobsController : ControllerBase
    {
        DataContextDapper _dapper;
        public JobsController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("")]
        [SwaggerOperation("Get all job posts")]
        public void GetAllJobPosts() { }

        [HttpGet("{jobPostId}")]
        [SwaggerOperation("Get job post by ID")]
        public void GetJobPostById() { }

        [HttpPost("")]
        [SwaggerOperation("Add new job post")]
        public void AddNewJobPost() { }

        [HttpPatch("{jobPostId}")]
        [SwaggerOperation("Edit a job post")]
        public void EditJobPost() { }
    }
}
