using CustomerApi.Controllers; 
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 
using Xunit;

namespace CustomerApi.Tests.Controller // Namespace para os testes
{
    public class CustomersControllerTests // Classe de testes do controlador
    {
        private readonly CustomersController _controller; // Controlador a ser testado
        private readonly CustomerContext _context; // Contexto do banco de dados em memória

        public CustomersControllerTests() // Configuração do ambiente de teste
        {
            var options = new DbContextOptionsBuilder<CustomerContext>() // Opções do contexto
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Banco de dados em memória
                .Options;

            _context = new CustomerContext(options); // Cria a instância do contexto
            _context.Database.EnsureDeleted();  // Limpa o banco de dados antes de cada teste
            _context.Database.EnsureCreated();   // Cria um novo banco de dados

            // Adiciona um cliente de teste
            _context.Customers.Add(new Customer { Id = 1, Nome = "Teste 1", CPF = "12345678901", Email = "test1@gmail.com" });
            _context.SaveChanges(); // Salva as alterações

            _controller = new CustomersController(_context); // Inicializa o controlador
        }

        [Fact]
        public void GetCustomers_ReturnsOkResult() // Teste para verificar se a ação Get retorna sucesso
        {
            var result = _controller.GetCustomers(); // Executa a ação

            var okResult = Assert.IsType<ActionResult<IEnumerable<Customer>>>(result); // Verifica o tipo do resultado
            var customers = Assert.IsAssignableFrom<IEnumerable<Customer>>(okResult.Value); // Verifica a lista de clientes
            Assert.Single(customers); // Confirma que há um cliente
        }

        [Fact]
        public void PutCustomer_ReturnsBadRequest_WhenIdIsInvalid() // Teste para ID inválido
        {
            var customer = new Customer { Id = 2, Nome = "Invalid Customer", CPF = "12345678902", Email = "invalid@gmail.com" }; // Cliente com ID inválido

            var result = _controller.PutCustomer(1, customer); // Executa a ação

            Assert.IsType<BadRequestResult>(result); // Verifica se o resultado é BadRequest
        }

        [Fact]
        public void DeleteCustomer_ReturnsNoContent() // Teste para verificar retorno de NoContent na exclusão
        {
            int customerId = 1; // ID do cliente a ser excluído

            var result = _controller.DeleteCustomer(customerId); // Executa a ação

            Assert.IsType<NoContentResult>(result); // Verifica se o resultado é NoContent
        }

        [Fact]
        public void PostCustomer_ReturnsBadRequest_WhenCustomerIsInvalid() // Teste para cliente nulo
        {
            var result = _controller.PostCustomer(null); // Tenta adicionar um cliente nulo

            Assert.IsType<BadRequestObjectResult>(result); // Verifica se o resultado é BadRequest
        }
    }
}
