using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiCoreBasics.Models.DbCtx;
using WebApiCoreBasics.Models.Entities;

namespace WebApiCoreBasics.DataLayer
{
    public class TransactionDataLayer : ITransactionDataLayer
    {
        public async Task<Transaction> GetByID(long id)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                Transaction? transactionByID = await dbContext.Transaction.FirstOrDefaultAsync(t => t.id == id);

                return transactionByID != null ? transactionByID : new Transaction();
            }
        }

        public async Task<List<Transaction>> GetByUserID(long id)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                Expression<Func<Transaction, bool>> userTransactionSearchPredicate = (t) => t.userId == id;

                if (dbContext.Transaction.Any(userTransactionSearchPredicate))
                    return await dbContext.Transaction.Where(userTransactionSearchPredicate).ToListAsync();

                return new List<Transaction>();
            }
        }
    }
}
