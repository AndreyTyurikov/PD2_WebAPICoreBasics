using WebApiCoreBasics.Models.DTO.Transaction;

namespace WebApiCoreBasics.Services
{
    public interface ITransactionService
    {
        public Task<TransactionDTO> Add(AddTransactionDTO transactionToAdd);
        Task<TransactionDTO> GetById(long id);
        Task<List<TransactionDTO>> GetByUserID(long id);
    }
}
