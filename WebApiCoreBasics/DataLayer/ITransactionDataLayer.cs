using WebApiCoreBasics.Models.Entities;

namespace WebApiCoreBasics
{
    public interface ITransactionDataLayer
    {
        Task<Transaction> GetByID(long id);
        Task<List<Transaction>> GetByUserID(long id);
    }
}