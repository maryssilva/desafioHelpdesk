using Helpdesk.API.Models;
using HelpdeskAPI.Data;
using HelpdeskAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.AsNoTracking().ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.customerId == id);
        }

        public Customer Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer Update(Customer customer)
        {
            var existing = _context.Customers.FirstOrDefault(c => c.customerId == customer.customerId);

            if (existing == null)
                return null;

            existing.customerName = customer.customerName;
            existing.customerEmail = customer.customerEmail;
            existing.customerCreatedAt = customer.customerCreatedAt;

            _context.SaveChanges();

            return existing;
        }

        public bool Delete(int id)
        {
            var c = _context.Customers.FirstOrDefault(c => c.customerId == id);

            if (c == null)
                return false;

            _context.Customers.Remove(c);
            _context.SaveChanges();

            return true;
        }
    }
}
