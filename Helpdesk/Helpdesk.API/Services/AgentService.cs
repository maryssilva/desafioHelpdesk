using Helpdesk.API.Models;
using HelpdeskAPI.Repositories.Interfaces;
using HelpdeskAPI.Services.Interfaces;

namespace HelpdeskAPI.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public IEnumerable<Agent> GetAll()
        {
            return _agentRepository.GetAll();
        }

        public Agent GetById(int id)
        {
            return _agentRepository.GetById(id);
        }

        public Agent Create(Agent agent)
        {
            if (string.IsNullOrWhiteSpace(agent.agentName))
                throw new Exception("O campo nome é obrigatório!");

            agent.agentCreatedAt = DateTime.UtcNow;

            return _agentRepository.Add(agent);
        }

        public Agent Update(Agent agent)
        {
            return _agentRepository.Update(agent);
        }

        public bool Delete(int id)
        {
            return _agentRepository.Delete(id);
        }
    }
}
