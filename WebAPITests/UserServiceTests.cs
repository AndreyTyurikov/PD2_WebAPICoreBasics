//using Moq;
//using WebApiCoreBasics;
//using WebApiCoreBasics.Models.DTO.User;
//using WebApiCoreBasics.Models.Entities;
//using WebApiCoreBasics.Services;

//namespace WebAPITests
//{
//    public class UserServiceTests
//    {
//        private static IPasswordService passwordService = new PasswordService();

//        private static AddUserDTO addUserDTO = new AddUserDTO() { name = "New User", password = "password" };
//        private static string userValidPassword = "MyStrongPassword";
//        private const string userNewPassword = "123";
//        private static long validUserID = 1;


//        private static User validUserFromDB = new User() { 
//                id = validUserID, 
//                name = "New User", 
//                registeredAt = DateTime.Now, 
//                passwordHash = passwordService.CreatePasswordHash(userValidPassword) 
//            };

//        private IUserDataLayer dataLayer;
//        private readonly IUserService userService;


//        public UserServiceTests()
//        {
//            Mock<IUserDataLayer> dataLayerMock = new Mock<IUserDataLayer>();

//            dataLayerMock.Setup(m => m.Add(It.IsAny<User>()).Result).Returns(validUserFromDB);
//            dataLayerMock.Setup(m => m.GetByID(It.Is<long>(id => id == 0)).Result).Returns(new User());
//            dataLayerMock.Setup(m => m.GetByID(It.Is<long>(id => id > 0)).Result).Returns(validUserFromDB);
//            dataLayerMock.Setup(m => m.UpdateUser(It.IsAny<User>()).Result).Returns(true);
//            dataLayerMock.Setup(m => m.UpdateUserPassword(It.IsAny<long>(), It.IsAny<byte[]>()).Result).Returns(true);

//            dataLayer = dataLayerMock.Object;

//            userService = new UserService(passwordService, dataLayer);
//        }

//        [Fact]
//        public async void ShouldCreateUserFromDto()
//        {
//            UserDTO addedUser = await userService.CreateUserFromDTO(addUserDTO);

//            Assert.NotNull(addedUser);
//        }

//        [Fact]
//        public async void ShouldReturnFalseOnTryingToUpdateNonExistentUser()
//        {
//            //Arrange - организация, подготовка объектов тестирования 
//            EditUserDTO editUserDTO = new EditUserDTO { id = 0, name = "User name updated" };

//            //Act - запуск процесса тестирования
//            bool isUserUpdated = await userService.UpdateUserFromDTO(editUserDTO);

//            //Assert - проверка результатов тестирования
//            Assert.False(isUserUpdated);
//        }

//        [Fact]
//        public async void ShouldReturnTrueOnTryingToUpdateExistentUser()
//        {
//            EditUserDTO editUserDTO = new EditUserDTO { id = validUserID, name = "User name updated" };

//            bool isUserUpdated = await userService.UpdateUserFromDTO(editUserDTO);

//            Assert.True(isUserUpdated);
//        }

//        [Fact]
//        public async void ShouldReturnFalseOnTryingToUpdatePasswordForNonExistentUser()
//        {
//            UpdateUserPasswordDTO updateUserPasswordDTO = 
//                new UpdateUserPasswordDTO { id = 0, oldPassword = userValidPassword, newPassword = userNewPassword };

//            bool isPasswordUpdated = await userService.UpdateUserPassword(updateUserPasswordDTO);

//            Assert.False(isPasswordUpdated);
//        }

//        [Fact]
//        public async void ShouldReturnTrueOnTryingToUpdateKnownPassword()
//        {
//            UpdateUserPasswordDTO updateUserPasswordDTO =
//               new UpdateUserPasswordDTO { 
//                   id = validUserID, 
//                   oldPassword = userValidPassword, 
//                   newPassword = userNewPassword
//               };

//            bool isPasswordUpdated = await userService.UpdateUserPassword(updateUserPasswordDTO);

//            Assert.True(isPasswordUpdated);
//        }

//        [Fact]
//        public async void ShouldReturnFalseOnTryingToUpdateUknownPassword()
//        {
//            UpdateUserPasswordDTO updateUserPasswordDTO =
//               new UpdateUserPasswordDTO
//               {
//                   id = validUserID,
//                   oldPassword = "InvalidOldPassword",
//                   newPassword = userNewPassword
//               };

//            bool isPasswordUpdated = await userService.UpdateUserPassword(updateUserPasswordDTO);

//            Assert.False(isPasswordUpdated);
//        }

//    }
//}
