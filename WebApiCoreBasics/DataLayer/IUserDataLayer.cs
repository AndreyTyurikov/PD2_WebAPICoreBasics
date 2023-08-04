using WebApiCoreBasics.Models.Entities;

namespace WebApiCoreBasics
{
    public interface IUserDataLayer
    {
        Task<User> Add(User newUser);
        Task<bool> DeleteByID(long id);
        Task<List<User>> GetAll();
        Task<User> GetByID(long id);
        Task<bool> UpdateUser(User userToEdit);
        Task<bool> UpdateUserPassword(long id, byte[] passwordHash);
    }
}