using Helpdesk.API.Models;

namespace HelpdeskAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        bool Delete(int id);
    }
}
