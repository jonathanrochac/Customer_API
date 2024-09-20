using Microsoft.EntityFrameworkCore;


public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
    public virtual  DbSet<Customer> Customers { get; set; }
}
