using Helpdesk.API.Models;

namespace HelpdeskAPI.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
        Ticket Add(Ticket ticket);
        Ticket Update(Ticket ticket);
        bool Delete(int id);
    }
}
