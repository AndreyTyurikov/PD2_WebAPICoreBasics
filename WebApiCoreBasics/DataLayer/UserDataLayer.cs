using WebApiCoreBasics.Models.DTO.User;
using WebApiCoreBasics.Models.Entities;
using WebApiCoreBasics.Models.DbCtx;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreBasics.DataLayer
{
    public class UserDataLayer : IUserDataLayer
    {
        public async Task<User> Add(User newUser)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                dbContext.Users.Add(newUser);

                await dbContext.SaveChangesAsync();

                return newUser;
            }
        }

        public async Task<bool> DeleteByID(long id)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                User? userToDelete = dbContext.Users.FirstOrDefault(u => u.id == id);

                if (userToDelete != null)
                {
                    dbContext.Users.Remove(userToDelete);

                    await dbContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<List<User>> GetAll()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                return await dbContext.Users.ToListAsync();
            }
        }

        public async Task<User> GetByID(long id)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                User? userById = await dbContext.Users.FirstOrDefaultAsync(u => u.id == id);

                return userById != null ? userById : new User();
            }
        }

        public async Task<bool> UpdateUser(User updatedUser)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                User? userToUpdateInDB = await dbContext.Users.FirstOrDefaultAsync(u => u.id == updatedUser.id);

                if (userToUpdateInDB != null)
                {
                    userToUpdateInDB.name = updatedUser.name;

                    await dbContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<bool> UpdateUserPassword(long id, byte[] passwordHash)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                User? userToUpdatePassword = await dbContext.Users.FirstOrDefaultAsync(u => u.id == id);

                if (userToUpdatePassword == null) return false;

                userToUpdatePassword.passwordHash = passwordHash;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
