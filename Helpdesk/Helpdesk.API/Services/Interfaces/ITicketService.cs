using Helpdesk.API.Models;

namespace HelpdeskAPI.Services.Interfaces
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
        Ticket Create(Ticket ticket);
        Ticket Update(Ticket ticket);
        bool Delete(int id);
    }
}
