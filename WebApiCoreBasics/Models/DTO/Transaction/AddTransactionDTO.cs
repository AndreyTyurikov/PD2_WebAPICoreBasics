using System.ComponentModel.DataAnnotations;

namespace WebApiCoreBasics.Models.DTO.Transaction
{
    public class AddTransactionDTO
    {
        [Required]
        public long userId { get; set; }
        [Required]
        public string details { get; set; }
        public double amount { get; set; }
    }
}
