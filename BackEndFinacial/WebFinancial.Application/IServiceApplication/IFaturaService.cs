
using WebFinancial.Application.Dtos;

namespace WebFinancial.Application.IServiceApplication;

public interface IFaturaService
{
    Task<List<FaturaDto>> GetAllFaturas();
    Task<FaturaDto> GetFaturaById(int faturaId);
    Task<FaturaDto> AddFatura(FaturaDto model);
    Task<FaturaDto> UpdateFatura(int faturaId, FaturaDto model);
    Task<bool> DeleteFatura(int faturaId);
   
}
