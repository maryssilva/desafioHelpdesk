using Helpdesk.API.Models;

namespace HelpdeskAPI.Services.Interfaces
{
    public interface IAgentService
    {
        IEnumerable<Agent> GetAll();
        Agent GetById(int id);
        Agent Create(Agent agent);
        Agent Update(Agent agent);
        bool Delete(int id);
    }
}
