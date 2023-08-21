namespace Referralapi.Contracts
{
    public interface IReferralRepository
    {

        public  Task<IEnumerable<dynamic>> GetReferredBy(long userId, long jobId, int pageNumber, int numberOfRows);
    }
}
