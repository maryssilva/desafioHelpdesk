using Helpdesk.API.Models;

namespace HelpdeskAPI.Repositories.Interfaces
{
    public interface IAgentRepository
    {
        IEnumerable<Agent> GetAll();
        Agent GetById(int id);
        Agent Add(Agent agent);
        Agent Update(Agent agent);
        bool Delete(int id);
    }
}
