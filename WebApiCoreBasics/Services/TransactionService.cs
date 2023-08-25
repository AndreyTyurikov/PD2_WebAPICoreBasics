using Mapster;
using WebApiCoreBasics.Models.Entities;
using WebApiCoreBasics.Models.DTO.Transaction;

namespace WebApiCoreBasics.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionIndexer _transactionIndexer;

        public TransactionService(ITransactionIndexer transactionIndexer)
        {
            _transactionIndexer = transactionIndexer;
        }

        public async Task<TransactionDTO> Add(AddTransactionDTO addTransactionDto)
        {
            Transaction transactionFromAddDto = addTransactionDto.Adapt<Transaction>();

            Transaction appliedTransaction = await _transactionIndexer.ApplyTransaction(transactionFromAddDto);

            return appliedTransaction.Adapt<TransactionDTO>();
        }

        public Task<TransactionDTO> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionDTO>> GetByUserID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
