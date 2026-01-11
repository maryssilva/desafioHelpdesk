using Helpdesk.API.Models;
using HelpdeskAPI.Data;
using HelpdeskAPI.Repositories.Interfaces;

namespace HelpdeskAPI.Repositories
{
    public class TicketEventRepository : ITicketEventRepository
    {
        public readonly AppDbContext _context;

        public TicketEventRepository (AppDbContext context)
        {
            _context = context;
        }

        public TicketEvent Add(TicketEvent ticketEvent)
        {
            _context.TicketEvents.Add(ticketEvent);
            _context.SaveChanges();

            return ticketEvent;
        }
    }
}
