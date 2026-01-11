namespace Helpdesk.API.Models
{
    public class Ticket
    {
        public int ticketId {  get; set; }

        public int customerFk {  get; set; }
        public Customer? Customer { get; set; }

        public int? agentFk { get; set; }
        public Agent? Agent { get; set; }

        public string title { get; set; } = string.Empty;
        public string ticketDescription { get; set; } = string.Empty;
        public string status { get; set; } = "Open";

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime? updatedAt { get; set; }
        public DateTime? resolvedAt { get; set; }
        public DateTime? closedAt { get; set; }

        //Relacionamento
        public ICollection<TicketEvent>? TicketEvents { get; set; }
    }
}
