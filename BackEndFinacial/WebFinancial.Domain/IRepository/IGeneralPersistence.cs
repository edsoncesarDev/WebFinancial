
using System.Linq.Expressions;

namespace WebFinancial.Data.IRepository;

public interface IGeneralPersistence<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(Expression<Func<T, bool>> id);
    void Add(T entity);
    void Update(T entity);
    void Delete(Expression<Func<T, bool>> id);

}
