using Microsoft.EntityFrameworkCore;
using WebApiCoreBasics.Models.DbCtx;
using WebApiCoreBasics.Models.Entities;

namespace WebApiCoreBasics.DataLayer
{
    public class AccountDataLayer : IAccountDataLayer
    {
        public async Task<Account> CreateForUser(User user)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                User? accountUser = dbContext.Users.FirstOrDefault(u => u.id == user.id);

                if (accountUser != null)
                {
                    Account accountForUser = new Account();

                    accountForUser.user = accountUser;

                    dbContext.Accounts.Add(accountForUser);

                    await dbContext.SaveChangesAsync();

                    return accountForUser;
                }

                return new Account();
            }
        }

        //TODO: Deal with null-ref warning
        public async Task<Account> GetByUser(User user)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                return await dbContext.Accounts.FirstOrDefaultAsync(a => a.user.id == user.id);
            }
        }
    }
}
