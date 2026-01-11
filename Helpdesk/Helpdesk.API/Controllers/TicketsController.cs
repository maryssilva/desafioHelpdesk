using Microsoft.AspNetCore.Mvc;
using Helpdesk.API.Models;
using HelpdeskAPI.Services.Interfaces;

namespace HelpdeskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService service)
        {
            _ticketService = service;
        }

        //GET/api/Tickets
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ticketService.GetAll());
        }

        //GET/api/Tickets/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _ticketService.GetById(id);

            if (result == null) 
                return NotFound();

            return Ok(result);
        }

        //POST/api/Tickets
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            var created = _ticketService.Create(ticket);

            return CreatedAtAction(nameof(GetById), new { id = created.ticketId }, created);
        }

        //PUT/api/Tickets/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Ticket ticket)
        {
            ticket.ticketId = id;

            var updated = _ticketService.Update(ticket);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        //DELETE/api/Tickets/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _ticketService.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
