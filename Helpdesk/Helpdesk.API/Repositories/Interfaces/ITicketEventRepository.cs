using Helpdesk.API.Models;

namespace HelpdeskAPI.Repositories.Interfaces
{
    public interface ITicketEventRepository
    {
        TicketEvent Add(TicketEvent ticketEvent);
    }
}
