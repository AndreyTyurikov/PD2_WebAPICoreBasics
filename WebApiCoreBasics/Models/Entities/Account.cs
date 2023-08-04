using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiCoreBasics.Models.Entities
{
    public class Account
    {
        [Key]
        public long id { get; set; }
        [Required]
        public long userId { get; set; }
        [Required]
        public double balance { get; set; }
        public User user { get; set; }
    }
}
