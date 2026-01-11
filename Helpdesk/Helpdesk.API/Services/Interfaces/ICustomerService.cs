using Helpdesk.API.Models;

namespace HelpdeskAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        bool Delete(int id);
    }
}
