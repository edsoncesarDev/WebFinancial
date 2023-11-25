
using Microsoft.EntityFrameworkCore;
using WebFinancial.Data.Context;
using WebFinancial.Data.IRepository;
using WebFinancial.Domain.Entities;

namespace WebFinancial.Data.Repository;

public class FaturaPersistence : IFaturaPersistence
{
    private readonly AppDbContext _context;

    public FaturaPersistence(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Fatura>> GetAllFaturasAsync()
    {
        IQueryable<Fatura> query = _context.Faturas;

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Fatura> GetFaturaByIdAsync(int id)
    {
        IQueryable<Fatura> query = _context.Faturas;

        return await query.AsNoTracking().Where(f => f.Id == id).FirstOrDefaultAsync();
    }



}
