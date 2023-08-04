using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCoreBasics.Models.Entities
{
    public class User
    {
        [Key]
        public long id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public byte[] passwordHash { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime registeredAt { get; set; }

        public ICollection<Transaction> transactions { get; } = new List<Transaction>();
        public Account? account { get; set; }
    }
}
