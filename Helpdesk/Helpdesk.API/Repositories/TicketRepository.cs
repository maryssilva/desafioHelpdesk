using Helpdesk.API.Models;
using HelpdeskAPI.Data;
using HelpdeskAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskAPI.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public readonly AppDbContext _context;

        public TicketRepository (AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets.AsNoTracking().ToList();
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.FirstOrDefault(t => t.ticketId == id);
        }

        public Ticket Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return ticket;
        }

        public Ticket Update(Ticket ticket)
        {
            var existing = _context.Tickets.FirstOrDefault(t => t.ticketId == ticket.ticketId);

            if (existing == null)
                return null;
            
            existing.customerFk = ticket.customerFk;
            existing.agentFk = ticket.agentFk;
            existing.title = ticket.title;
            existing.ticketDescription = ticket.ticketDescription;
            existing.status = ticket.status;
            existing.createdAt = ticket.createdAt;
            existing.updatedAt = ticket.updatedAt;
            existing.resolvedAt = ticket.resolvedAt;
            existing.closedAt = ticket.closedAt;

            _context.SaveChanges();

            return existing;
        }

        public bool Delete(int id)
        {
            var t = _context.Tickets.FirstOrDefault(t => t.ticketId == id);

            if (t == null)
                return false;

            _context.Remove(t);
            _context.SaveChanges();

            return true;
        }
    }
}
