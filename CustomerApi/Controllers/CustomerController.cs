using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context; // Contexto do banco de dados

        public CustomersController(CustomerContext context) // Construtor que inicializa o contexto
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers() // Retorna a lista de clientes
        {
            return _context.Customers.ToList();
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer) // Atualiza um cliente existente
        {
            if (id != customer.Id) // Verifica se o ID do cliente corresponde ao parâmetro
            {
                return BadRequest(); // Retorna erro se os IDs não coincidirem
            }

            _context.Update(customer); // Atualiza o cliente no contexto
            _context.SaveChanges(); // Salva as mudanças no banco de dados

            return NoContent(); // Retorna status 204 se a atualização for bem-sucedida
        }

        // POST: api/customers
        [HttpPost]
        public IActionResult PostCustomer(Customer customer) // Adiciona um novo cliente
        {
            if (customer == null) // Verifica se o cliente é nulo
            {
                return BadRequest("Customer is null."); // Retorna erro se o cliente for nulo
            }

            _context.Customers.Add(customer); // Adiciona o cliente ao contexto
            _context.SaveChanges(); // Salva as mudanças no banco de dados

            return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, customer); // Retorna 201 Created com a localização do novo cliente
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id) // Remove um cliente
        {
            var customer = _context.Customers.Find(id); // Procura o cliente pelo ID
            if (customer == null) return NotFound(); // Retorna erro se o cliente não for encontrado

            _context.Customers.Remove(customer); // Remove o cliente do contexto
            _context.SaveChanges(); // Salva as mudanças no banco de dados

            return NoContent(); // Retorna status 204 se a remoção for bem-sucedida
        }
    }
}
