using WebApiCoreBasics.Models.DbCtx;
using WebApiCoreBasics.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreBasics.Services
{
    public class TransactionIndexer : ITransactionIndexer
    {
        private readonly Transaction failedTransaction = new Transaction { id = -1 };
        private readonly IAccountDataLayer _accountDataLayer;

        public TransactionIndexer(IAccountDataLayer accountDataLayer)
        {
            _accountDataLayer = accountDataLayer;
        }

        public async Task<Transaction> ApplyTransaction(Transaction transactionToAdd)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                User userForTransaction = await dbContext.Users.FirstOrDefaultAsync(u => u.id == transactionToAdd.userId);

                if (userForTransaction == null) return failedTransaction;

                Account accountForTransaction = await dbContext.Accounts.FirstOrDefaultAsync(u => u.userId == transactionToAdd.userId);

                if (accountForTransaction == null)
                {
                    //Reference will be lost
                    Account createdAccount = await _accountDataLayer.CreateForUser(userForTransaction);
                    //Reference renewal
                    accountForTransaction = await dbContext.Accounts.FirstOrDefaultAsync(a => a.id == createdAccount.id);
                }
                    
                //No account found or created
                if (accountForTransaction.id == 0) return failedTransaction;

                //Now we have all: Account, User and Transaction
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    accountForTransaction.balance += transactionToAdd.amount;

                    int accountRowsUpdated = await dbContext.SaveChangesAsync();

                    //Balance update failure
                    if (accountRowsUpdated == 0) {

                        transaction.Rollback();
                        return failedTransaction;

                    }

                    transactionToAdd.user = userForTransaction;
                    dbContext.Transaction.Add(transactionToAdd);

                    int transactionsAdded = await dbContext.SaveChangesAsync();

                    //Transaction addition failure
                    if (transactionsAdded == 0)
                    {

                        transaction.Rollback();
                        return failedTransaction;

                    }

                    transaction.Commit();
                    return transactionToAdd;
                }
            }
        }
    }
}
