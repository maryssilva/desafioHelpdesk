using Helpdesk.API.Models;
using HelpdeskAPI.Repositories.Interfaces;
using HelpdeskAPI.Services.Interfaces;

namespace HelpdeskAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer Create(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.customerName))
                throw new Exception("O campo nome é obrigatório!");

            if (string.IsNullOrWhiteSpace(customer.customerEmail))
                throw new Exception("O campo e-mail é obrigatório!");

            customer.customerCreatedAt = DateTime.UtcNow;

            return _customerRepository.Add(customer);
        }

        public Customer Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }
    }
}
