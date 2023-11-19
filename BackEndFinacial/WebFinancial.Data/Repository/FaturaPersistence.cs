
using WebFinancial.Data.Context;
using WebFinancial.Data.IRepository;
using WebFinancial.Domain.Entities;

namespace WebFinancial.Data.Repository;

public class FaturaPersistence : GeneralPersistence<Fatura>, IFaturaPersistence
{
    public FaturaPersistence(AppDbContext context) : base(context) { }
    
}
