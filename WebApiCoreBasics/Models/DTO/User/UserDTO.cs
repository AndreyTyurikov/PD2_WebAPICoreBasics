using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiCoreBasics.Models.DTO.User
{
    public class UserDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public DateTime registeredAt { get; set; }
        public double balance { get; set; }
    }
}
