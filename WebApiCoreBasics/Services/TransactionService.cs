using Mapster;
using WebApiCoreBasics.Models.Entities;
using WebApiCoreBasics.Models.DTO.Transaction;

namespace WebApiCoreBasics.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionIndexer _transactionIndexer;
        private readonly ITransactionDataLayer _transactionDataLayer;

        public TransactionService(ITransactionIndexer transactionIndexer, ITransactionDataLayer transactionDataLayer)
        {
            _transactionIndexer = transactionIndexer;
            _transactionDataLayer = transactionDataLayer;
        }

        public async Task<TransactionDTO> Add(AddTransactionDTO addTransactionDto)
        {
            Transaction transactionFromAddDto = addTransactionDto.Adapt<Transaction>();

            Transaction appliedTransaction = await _transactionIndexer.ApplyTransaction(transactionFromAddDto);

            return appliedTransaction.Adapt<TransactionDTO>();
        }

        public async Task<TransactionDTO> GetById(long id)
        {
            Transaction transactionByID = await _transactionDataLayer.GetByID(id);

            return transactionByID.Adapt<TransactionDTO>();
        }

        public async Task<List<TransactionDTO>> GetByUserID(long id)
        {
            List<Transaction> transactionsByUser = await _transactionDataLayer.GetByUserID(id);

            return transactionsByUser.Adapt<List<TransactionDTO>>();
        }
    }
}
