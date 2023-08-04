using WebApiCoreBasics.Models.Entities;

namespace WebApiCoreBasics
{
    public interface IAccountDataLayer
    {
        Task<Account> CreateForUser(User user);
        Task<Account> GetByUser(User user);
    }
}