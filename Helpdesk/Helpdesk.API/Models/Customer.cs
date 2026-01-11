namespace Helpdesk.API.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; } = string.Empty;
        public string customerEmail { get; set; } = string.Empty;
        public DateTime customerCreatedAt { get; set; } = DateTime.UtcNow;

        //Relacionamento
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
