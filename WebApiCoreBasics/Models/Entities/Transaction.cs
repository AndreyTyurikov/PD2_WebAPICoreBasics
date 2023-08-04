using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCoreBasics.Models.Entities
{
    public class Transaction
    {
        [Key]
        public long id { get; set; }
        [Required]
        public long userId { get; set; }
        [Required]
        public double amount { get; set; }
        [Required]
        public string details { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime dateTime { get; set; }
        public User user { get; set; }
    }
}
