using Microsoft.Extensions.Configuration;
using Referralapi.Contracts;
using System.Data.SqlClient;
using System.Data;
using Referralapi.Context;
using Dapper;

namespace Referralapi.Repository
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly DapperContext _context;
        public ReferralRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<dynamic>> GetReferredBy(long userId, long jobId, int pageNumber, int numberOfRows)
        {


            var parameters = new
            {
                UserId = userId,
                JobId = jobId,
                PageNumber = pageNumber,
                NumberOfRows = numberOfRows
            };

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<dynamic>("Usp_Get_ReferredBy", parameters , commandType: CommandType.StoredProcedure);
                return result.ToList();
            }

        }
        
    }
}
