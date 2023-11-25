
using WebFinancial.Data.Context;
using WebFinancial.Data.IRepository;
using WebFinancial.Data.IRepositoryPattern;
using WebFinancial.Data.Repository;

namespace WebFinancial.Data.RepositoryPattern;

public class UnitOfWork : IUnitOfWork
{
    public AppDbContext _context;
    private FaturaPersistence _faturaPersistence;
    private GeneralPersistence _generalPersistence;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IFaturaPersistence FaturaPersistence 
    {
        get
        {
            return _faturaPersistence = _faturaPersistence ?? new FaturaPersistence(_context);
        }
    }

    public IGeneralPersistence GeneralPersistence 
    {
        get
        {
            return _generalPersistence = _generalPersistence ?? new GeneralPersistence(_context);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
