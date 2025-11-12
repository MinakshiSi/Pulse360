namespace CreditService.Domain.Entities
{
    public class CreditProfile
    {
        public Guid UserId { get; set; }
        public int Score { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
