using Helpdesk.API.Models;
using HelpdeskAPI.Data;
using HelpdeskAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskAPI.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext _context;

        public AgentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Agent> GetAll()
        {
            return _context.Agents.AsNoTracking().ToList();
        }

        public Agent GetById(int id)
        {
            return _context.Agents.FirstOrDefault(a => a.agentId == id);
        }

        public Agent Add(Agent agent)
        {
            _context.Agents.Add(agent);
            _context.SaveChanges();

            return agent;
        }

        public Agent Update(Agent agent)
        {
            var existing = _context.Agents.FirstOrDefault(a => a.agentId == agent.agentId);

            if (existing == null)
                return null;

            existing.agentName = agent.agentName;
            existing.isActive = agent.isActive;
            existing.agentCreatedAt = agent.agentCreatedAt;

            _context.SaveChanges();

            return existing;
        }

        public bool Delete(int id)
        {
            var a = _context.Agents.FirstOrDefault(a => a.agentId == id);

            if (a == null)
                return false;

            _context.Agents.Remove(a);
            _context.SaveChanges();

            return true;
        }
    }
}
