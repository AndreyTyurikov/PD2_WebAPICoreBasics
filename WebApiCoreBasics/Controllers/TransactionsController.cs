using Microsoft.AspNetCore.Mvc;
using WebApiCoreBasics.Models.DTO.Transaction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCoreBasics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        // GET api/Transactions/5
        // ByTransactionID
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/Transactions/user/5
        // ByTransactionID
        [HttpGet("user/{id}")]
        public string GetByUserID(int id)
        {
            return "value";
        }

        // POST api/Transactions
        [HttpPost]
        public async Task<TransactionDTO> Post([FromBody] AddTransactionDTO newTransaction)
        {
            if (ModelState.IsValid)
            {
                return new TransactionDTO();
                //TODO: Add to service
            }
            else
            {
                 
            }
        }
    }
}
