using WebFinancial.Domain.Entities;

namespace WebFinancial.Data.IRepository
{
    public interface IFaturaPersistence
    {
        Task<IEnumerable<Fatura>> GetAllFaturasAsync();
        Task<Fatura> GetFaturaByIdAsync(int id);
    }
}
