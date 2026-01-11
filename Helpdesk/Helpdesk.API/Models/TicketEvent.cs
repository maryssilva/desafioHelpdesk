namespace Helpdesk.API.Models
{
    public class TicketEvent
    {
        public int ticketEventId { get; set; }

        public int ticketFk {  get; set; }
        public Ticket? Ticket { get; set; }

        public int? agentFk { get; set; }
        public Agent? Agent { get; set; }

        public string? oldStatus { get; set; } = string.Empty;
        public string? newStatus { get; set; } = string.Empty;

        public DateTime eventChangedAt { get; set; } = DateTime.UtcNow;
    }
}
