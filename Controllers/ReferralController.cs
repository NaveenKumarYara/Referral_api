using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Referralapi.Contracts;

namespace Referralapi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly IReferralRepository _referralRepository;

        public ReferralController(IReferralRepository referralRepository)
        {
            _referralRepository = referralRepository;
        }

        [HttpGet("ReferredBy")]
        public async Task<IActionResult> GetReferredBy(long userId, long jobId, int pageNumber = 1, int numberOfRows = 3)
        {
            try
            {


                var jobs = await _referralRepository.GetReferredBy(userId, jobId, pageNumber, numberOfRows);
                if (jobs == null)
                    return NotFound();

                return Ok(jobs);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
           
        }


    }
}
