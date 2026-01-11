using Microsoft.AspNetCore.Mvc;
using Helpdesk.API.Models;
using HelpdeskAPI.Services.Interfaces;

namespace HelpdeskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService service)
        {
            _customerService = service;
        }

        //GET/api/Customers
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        //GET/api/Customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //POST/api/Customers
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var created = _customerService.Create(customer);

            return CreatedAtAction(nameof(GetById), new { id = created.customerId }, created);
        }

        //PUT/api/Customers/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            customer.customerId = id;

            var updated = _customerService.Update(customer);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        //DELETE/api/Customers/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _customerService.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}

//        // GET: Customers
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Customers.ToListAsync());
//        }

//        // GET: Customers/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer = await _context.Customers
//                .FirstOrDefaultAsync(m => m.customerId == id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return View(customer);
//        }

//        // GET: Customers/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Customers/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("customerId,customerName,customerEmail,customerCreatedAt")] Customer customer)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(customer);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(customer);
//        }

//        // GET: Customers/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer = await _context.Customers.FindAsync(id);
//            if (customer == null)
//            {
//                return NotFound();
//            }
//            return View(customer);
//        }

//        // POST: Customers/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("customerId,customerName,customerEmail,customerCreatedAt")] Customer customer)
//        {
//            if (id != customer.customerId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(customer);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CustomerExists(customer.customerId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(customer);
//        }

//        // GET: Customers/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer = await _context.Customers
//                .FirstOrDefaultAsync(m => m.customerId == id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return View(customer);
//        }

//        // POST: Customers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer != null)
//            {
//                _context.Customers.Remove(customer);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CustomerExists(int id)
//        {
//            return _context.Customers.Any(e => e.customerId == id);
//        }
//    }
//}
