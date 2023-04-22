using api.Data;

namespace api.Helpers
{
    public class CheckIdHelper
    {
        private readonly DataContextDapper _dapper;
        public CheckIdHelper(DataContextDapper dapper)
        {
            _dapper = dapper;
        }

        public bool CheckLocationId(int id)
        {
            string sql = "SELECT LocationId FROM PortalSchema.Locations WHERE LocationId = @LocationId";
            IEnumerable<int> existingLocation = _dapper.LoadData<int>(sql, new { LocationId = id });

            if (existingLocation.Any())
            {
                return true;
            }
            return false;
        }

        public bool CheckUserId(int id)
        {
            string sqlCheckUserId = "SELECT UserId FROM PortalSchema.Users WHERE UserId = @UserId";

            IEnumerable<int> existingUser = _dapper.LoadData<int>(sqlCheckUserId, new { UserId = id });
            if (existingUser.Any())
            {
                return true;
            }
            return false;
        }
    }
}
