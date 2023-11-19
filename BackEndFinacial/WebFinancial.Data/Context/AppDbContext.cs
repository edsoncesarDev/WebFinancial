
using Microsoft.EntityFrameworkCore;
using WebFinancial.Domain.Entities;

namespace WebFinancial.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Fatura> Faturas { get; set; }
    public DbSet<Compra> Compras { get; set; }

}
