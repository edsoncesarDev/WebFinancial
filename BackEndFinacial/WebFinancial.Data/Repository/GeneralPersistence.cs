
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebFinancial.Data.Context;
using WebFinancial.Data.IRepository;

namespace WebFinancial.Data.Repository;

public class GeneralPersistence<T> : IGeneralPersistence<T> where T: class
{
    private AppDbContext _context;
    private DbSet<T> _table;

    public GeneralPersistence(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _table.AsNoTracking().ToListAsync();
    }

    public async Task<T> GetById(Expression<Func<T, bool>> id)
    {
        return await _table.FirstOrDefaultAsync(id);
    }

    public void Add(T entity)
    {
        _table.Add(entity);
    }

    public void Update(T entity)
    {
        _table.Entry(entity).State = EntityState.Modified;
        _table.Update(entity);
    }

    public void Delete(Expression<Func<T, bool>> id)
    {
        T existing = _table.Find(id);
        _table.Remove(existing);
    }
    
}
