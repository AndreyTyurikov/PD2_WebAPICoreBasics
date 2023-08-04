using WebApiCoreBasics.Models.Entities;

namespace WebApiCoreBasics.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataLayer _accountDataLayer;

        public AccountService(IAccountDataLayer accountDataLayer)
        {
            _accountDataLayer = accountDataLayer;
        }

        public async Task<Account> CreateAccountForUser(User user)
        {
            if(user != null && user.id > 0)
            {
                Account userAccount = await _accountDataLayer.CreateForUser(user);

                return userAccount;
            }
            else return new Account();
        }

        public async Task<Account> GetByUser(User user)
        {
            return await _accountDataLayer.GetByUser(user);
        }
    }
}
