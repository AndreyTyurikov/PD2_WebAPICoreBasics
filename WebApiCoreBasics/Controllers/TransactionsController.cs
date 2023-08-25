using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiCoreBasics.Models.DTO.Transaction;
using WebApiCoreBasics.Services;

namespace WebApiCoreBasics.Controllers
{
    //TODO: Switch to CustomApiResponse Model
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET api/Transactions/5
        // ByTransactionID
        [HttpGet("{id}")]
        public async Task<TransactionDTO> Get(long id)
        {
            TransactionDTO transactionById = await _transactionService.GetById(id);

            return transactionById;
        }

        // GET api/Transactions/user/5
        // ByTransactionID
        [HttpGet("user/{id}")]
        public async Task<List<TransactionDTO>> GetByUserID(long id)
        {
            List<TransactionDTO> transactionByUserId = await _transactionService.GetByUserID(id);

            return transactionByUserId;
        }

        // POST api/Transactions
        [HttpPost]
        public async Task<TransactionDTO> Post([FromBody] AddTransactionDTO newTransaction)
        {
            //TODO: Use ModelState to validate Model
            TransactionDTO addedTransaction = await _transactionService.Add(newTransaction);

            return addedTransaction;
        }
    }
}
