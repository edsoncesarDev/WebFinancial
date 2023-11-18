
using Microsoft.EntityFrameworkCore;

namespace WebFinancial.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

}
