using WebApiCoreBasics.Models.Entities;

using Mapster;
using WebApiCoreBasics.Models.DTO.User;

namespace WebApiCoreBasics.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserDataLayer _userDataLayer;
        private readonly IAccountService _accountService;

        public UserService(
                IPasswordService passwordService, 
                IUserDataLayer userDataLayer,
                IAccountService accountService
            )
        {
            _passwordService = passwordService;
            _userDataLayer = userDataLayer;
            _accountService = accountService;
        }

        public async Task<UserDTO> CreateUserFromDTO(AddUserDTO userToAdd)
        {
            User newUser = userToAdd.Adapt<User>();

            newUser.passwordHash = _passwordService.CreatePasswordHash(userToAdd.password);

            User addedUser = await _userDataLayer.Add(newUser);

            await _accountService.CreateAccountForUser(addedUser);

            UserDTO userDtoToReturn = addedUser.Adapt<UserDTO>();

            return userDtoToReturn;
        }

        public async Task<bool> DeleteUserByID(long id)
        {
            bool isUserDeleted = await _userDataLayer.DeleteByID(id);

            return isUserDeleted;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            List<User> allUsers = await _userDataLayer.GetAll();

            return allUsers.Adapt<List<UserDTO>>();
        }

        public async Task<UserDTO> GetUserByID(long id)
        {
            User userByID = await _userDataLayer.GetByID(id);

            return userByID.Adapt<UserDTO>();
        }

        public async Task<bool> UpdateUserFromDTO(EditUserDTO editUserDTO)
        {
            User userToUpdate = await _userDataLayer.GetByID(editUserDTO.id);

            if (userToUpdate.id == 0) return false;

            //Update section
            userToUpdate.name = editUserDTO.name;

            return await _userDataLayer.UpdateUser(userToUpdate);
        }

        public async Task<bool> UpdateUserPassword(UpdateUserPasswordDTO updateUserPasswordDTO)
        {
            User userByID = await _userDataLayer.GetByID(updateUserPasswordDTO.id);

            if (userByID.id == 0) return false;

            Byte[] oldPasswordHash = userByID.passwordHash;

            if (_passwordService.ValidatePasswordAgainstHash(oldPasswordHash, updateUserPasswordDTO.oldPassword))
            {                
                userByID.passwordHash = _passwordService.CreatePasswordHash(updateUserPasswordDTO.newPassword);

                return await _userDataLayer.UpdateUserPassword(userByID.id, userByID.passwordHash);
            }
            else return false;
        }
    }
}
