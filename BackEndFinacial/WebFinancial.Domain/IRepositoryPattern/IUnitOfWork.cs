
using WebFinancial.Data.IRepository;

namespace WebFinancial.Data.IRepositoryPattern;

public interface IUnitOfWork
{
    IFaturaPersistence FaturaPersistence { get; }
    Task<bool> SaveChangesAsync();
}
