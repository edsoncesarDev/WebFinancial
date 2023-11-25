
using Microsoft.EntityFrameworkCore;
using WebFinancial.Data.Context;
using WebFinancial.Data.IRepository;

namespace WebFinancial.Data.Repository;

public class GeneralPersistence : IGeneralPersistence
{
    private AppDbContext _context;

    public GeneralPersistence(AppDbContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }
    
}
