using Helpdesk.API.Models;
using HelpdeskAPI.Repositories.Interfaces;
using HelpdeskAPI.Services.Interfaces;

namespace HelpdeskAPI.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketEventRepository _ticketEventRepository;

        public TicketService(ITicketRepository repository, ITicketEventRepository ticketEventRepository)
        {
            _ticketRepository = repository;
            _ticketEventRepository = ticketEventRepository;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetById(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public Ticket Create(Ticket ticket)
        {
            if (string.IsNullOrWhiteSpace(ticket.title))
                throw new Exception("O campo título é obrigatório!");

            if (string.IsNullOrWhiteSpace(ticket.ticketDescription))
                throw new Exception("O campo descrição é obrigatório!");

            ticket.status = "Open";
            ticket.createdAt = DateTime.UtcNow;

            return _ticketRepository.Add(ticket);
        }

        public Ticket Update(Ticket ticket)
        {
            var existing = _ticketRepository.GetById(ticket.ticketId);

            if (existing == null)
                return null;

            var oldStatus = existing.status;

            if (ticket.agentFk.HasValue)
                existing.agentFk = ticket.agentFk;

            if (!string.IsNullOrWhiteSpace(ticket.title))
                existing.title = ticket.title;

            if (!string.IsNullOrWhiteSpace(ticket.ticketDescription))
                existing.ticketDescription = ticket.ticketDescription;

            var validStatus = new[] { "Open", "Resolved", "Closed" };

            if (!string.IsNullOrWhiteSpace(ticket.status))
            {
                if (!validStatus.Contains(ticket.status))
                    throw new Exception("Status inválido.");

                if (existing.status != ticket.status)
                {
                    existing.status = ticket.status;

                    if (ticket.status == "Resolved")
                        existing.resolvedAt = DateTime.UtcNow;

                    if (ticket.status == "Closed")
                        existing.closedAt = DateTime.UtcNow;
                }
            }

            existing.updatedAt = DateTime.UtcNow;

            var updated = _ticketRepository.Update(existing);

            //LÓGICA PARA ticketEvent
            if (oldStatus != updated.status)
            {
                //Console.WriteLine("CRIANDO TICKET EVENT");

                var history = new TicketEvent
                {
                    ticketFk = updated.ticketId,
                    oldStatus = oldStatus,
                    newStatus = updated.status,
                    //agentFk = updated.agentFk,
                    eventChangedAt = DateTime.UtcNow
                };

                _ticketEventRepository.Add(history);
            }

            return updated;
        }

        public bool Delete(int id)
        {
            return _ticketRepository.Delete(id);
        }
    }
}
