using WebApiCoreBasics.Models.Entities;

namespace WebApiCoreBasics.Services
{
    public interface ITransactionIndexer
    {
        Task<Transaction> ApplyTransaction(Transaction transactionToAdd);
    }
}
