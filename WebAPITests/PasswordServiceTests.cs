using WebApiCoreBasics.Services;

namespace WebAPITests
{
    public class PasswordServiceTests
    {
        private readonly PasswordService passwordService = new PasswordService();
        private readonly string rightPassword = "rightPassword";
        private readonly string wrongPassword = "wrongPassword";
        private const int HASH_SIZE = 32;

        [Fact]
        public void ShouldCreateHashOnInputString()
        {
            byte[] hashOfString = passwordService.CreatePasswordHash(rightPassword);
            
            Assert.NotNull(hashOfString);
            Assert.NotEmpty(hashOfString);

            Assert.True(hashOfString.Length == HASH_SIZE);
        }

        [Fact]
        public void ShouldReturnFalseOnHashCheckWithWrongLength()
        {
            bool hashValidationResult = passwordService.ValidatePasswordAgainstHash(new byte[HASH_SIZE + 1], rightPassword);

            Assert.False(hashValidationResult);
        }

        [Fact]
        public void ShouldReturnTrueOnCheckingRightStringAgainstRightHash()
        {
            byte[] hashOfRightPassword = passwordService.CreatePasswordHash(rightPassword);

            bool hashValidationResult = passwordService.ValidatePasswordAgainstHash(hashOfRightPassword, rightPassword);

            Assert.True(hashValidationResult);
        }

        [Fact]
        public void ShouldReturnFalseOnCheckingWrongStringAgainstRightHash()
        {
            byte[] hashOfRightPassword = passwordService.CreatePasswordHash(rightPassword);

            bool hashValidationResult = passwordService.ValidatePasswordAgainstHash(hashOfRightPassword, wrongPassword);

            Assert.False(hashValidationResult);
        }
    }
}