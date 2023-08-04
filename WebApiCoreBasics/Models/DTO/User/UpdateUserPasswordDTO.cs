namespace WebApiCoreBasics.Models.DTO.User
{
    public class UpdateUserPasswordDTO
    {
        public long id { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
