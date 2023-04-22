using api.Helpers;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using api.Dtos.User;
using System.Security.Cryptography;

namespace api.Controllers.User
{
    [ApiController]
    [Route("Users")]
    //[SwaggerTag("User")]
    public partial class UsersController : ControllerBase
    {
        readonly DataContextDapper _dapper;
        readonly AuthHelper _authHelper;
        readonly IWebHostEnvironment _hostingEnvironment;
        readonly FilesHelper _filesHelper;
        readonly CheckIdHelper _checkIdHelper;

        public UsersController(IConfiguration config, IWebHostEnvironment hostingEnvironment)
        {
            _dapper = new DataContextDapper(config);
            _authHelper = new AuthHelper(config);
            _hostingEnvironment = hostingEnvironment;
            _filesHelper = new FilesHelper(_hostingEnvironment);
            _checkIdHelper = new CheckIdHelper(_dapper);
        }

        [HttpPatch("{userId}")]
        [SwaggerOperation("edit user data", Tags = new[] { "User" })]
        public async Task<IActionResult> EditUserData([FromForm] UserEditDto userForEdit, int userId)
        {
            // verify user id
            if (!_checkIdHelper.CheckUserId(userId))
            {
                return BadRequest("Invalid user id");
            }

            // change location
            if (userForEdit.LocationId != null)
            {
                if (!_checkIdHelper.CheckLocationId((int)userForEdit.LocationId))
                {
                    return BadRequest("Invalid location id");
                }
                string sqlUpdateLocation = "UPDATE PortalSchema.Users SET LocationId = @LocationId WHERE UserId = @UserId";
                bool successUpdateLocation = _dapper.ExecuteSqlWithParameters(
                    sqlUpdateLocation, new { userForEdit.LocationId, UserId = userId }
                );
                if (!successUpdateLocation)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            // change password
            if (!string.IsNullOrEmpty(userForEdit.Password) && !string.IsNullOrEmpty(userForEdit.PasswordConfirm))
            {
                if (userForEdit.Password == userForEdit.PasswordConfirm)
                {
                    //set password hash & salt
                    byte[] passwordSalt = new byte[128 / 8];
                    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                    {
                        rng.GetNonZeroBytes(passwordSalt);
                    }
                    byte[] passwordHash = _authHelper.GetPasswordHash(userForEdit.Password, passwordSalt);

                    string sqlChangePassword = @"UPDATE PortalSchema.Users SET 
                        PasswordHash = @passwordHash, 
                        PasswordSalt = @passwordSalt 
                        WHERE UserId = @userId";

                    var paraSqlChangePassword = new
                    {
                        passwordHash,
                        passwordSalt,
                        userId
                    };
                    bool SuccessUpdatePassword = _dapper.ExecuteSqlWithParameters(sqlChangePassword, paraSqlChangePassword);
                    if (!SuccessUpdatePassword)
                    {
                        return BadRequest(StatusCodes.Status500InternalServerError);
                    }
                }
                else
                {
                    return BadRequest("Mismatched passwords");
                }
            }

            // upload new cv
            if (userForEdit.Cv != null)
            {
                if (!userForEdit.Cv.FileName.EndsWith(".pdf"))
                {
                    return BadRequest("Please upload a valid PDF file for CV");
                }
                // file uploaded
                string uploadedCvName = await _filesHelper.UploadFileAsync(userForEdit.Cv);

                // get old file name
                string sqlOldCv = "SELECT Cv FROM PortalSchema.Users WHERE UserId = @userId";
                string oldCv = _dapper.LoadDataSingle<string>(sqlOldCv, new { userId });
                if (oldCv == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                // update new file name
                string sqlUpdateCv = @"UPDATE PortalSchema.Users SET 
                        Cv = @Cv 
                        WHERE UserId = @userId";
                bool updateCv = _dapper.ExecuteSqlWithParameters(sqlUpdateCv, new { Cv = uploadedCvName, userId });

                if (!updateCv)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                // delete old file
                bool deleteCv = _filesHelper.DeleteFile(oldCv);
                if (!deleteCv)
                {
                    return BadRequest("Could not delete old cv");
                }
            }

            // upload new coverLetter
            if (userForEdit.CoverLetter != null)
            {
                if (!userForEdit.CoverLetter.FileName.EndsWith(".pdf"))
                {
                    return BadRequest("Please upload a valid PDF file for cover letter");
                }
                string uploadedCoverLetterName = await _filesHelper.UploadFileAsync(userForEdit.CoverLetter);

                string sqlOldCoverLetter = "SELECT CoverLetter FROM PortalSchema.Users WHERE UserId = @userId";
                string oldCoverLetter = _dapper.LoadDataSingle<string>(sqlOldCoverLetter, new { userId });
                if (oldCoverLetter == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                string sqlUpdateCoverLetter = @"UPDATE PortalSchema.Users SET 
                        CoverLetter = @CoverLetter 
                        WHERE UserId = @userId";
                bool updateCv = _dapper.ExecuteSqlWithParameters(sqlUpdateCoverLetter, new { CoverLetter = uploadedCoverLetterName, userId });

                if (!updateCv)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                bool deleteCoverLetter = _filesHelper.DeleteFile(oldCoverLetter);
                if (!deleteCoverLetter)
                {
                    return BadRequest("Could not delete old cover letter");
                }
            }

            return Ok();
        }
    }
}
