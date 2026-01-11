using Microsoft.AspNetCore.Mvc;
using Helpdesk.API.Models;
using HelpdeskAPI.Services.Interfaces;

namespace HelpdeskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentsController(IAgentService service)
        {
            _agentService = service;
        }

        //GET/api/Agents
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_agentService.GetAll());
        }

        //GET/api/Agents/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _agentService.GetById(id);

            if (result == null) 
                return NotFound();

            return Ok(result);
        }

        //POST/api/Agents
        [HttpPost]
        public IActionResult Create(Agent agent)
        {
            var created = _agentService.Create(agent);

            return CreatedAtAction(nameof(GetById), new { id = created.agentId }, created);
        }

        //PUT/api/Agents/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Agent agent)
        {
            agent.agentId = id;

            var updated = _agentService.Update(agent);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        //DELETE/api/Agents/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _agentService.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
