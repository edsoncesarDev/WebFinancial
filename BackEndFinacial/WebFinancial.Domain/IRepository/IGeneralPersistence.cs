

namespace WebFinancial.Data.IRepository;

public interface IGeneralPersistence
{
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;

}
