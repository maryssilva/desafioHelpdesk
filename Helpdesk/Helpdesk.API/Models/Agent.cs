namespace Helpdesk.API.Models
{
    public class Agent
    {
        public int? agentId {  get; set; }
        public string agentName { get; set; } = string.Empty;
        public bool isActive { get; set; }
        public DateTime agentCreatedAt { get; set; } = DateTime.UtcNow;

        //Relacionamento
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
