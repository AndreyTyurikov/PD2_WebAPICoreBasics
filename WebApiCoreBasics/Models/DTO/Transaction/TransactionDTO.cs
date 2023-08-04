namespace WebApiCoreBasics.Models.DTO.Transaction
{
    public class TransactionDTO
    {
        public long id { get; set; }
        public long userId { get; set; }
        public double amount { get; set; }
        public string details { get; set; }
        public DateTime dateTime { get; set; }
    }
}
