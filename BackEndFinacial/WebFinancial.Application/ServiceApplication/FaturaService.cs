
using AutoMapper;
using WebFinancial.Application.Dtos;
using WebFinancial.Application.IServiceApplication;
using WebFinancial.Data.IRepositoryPattern;
using WebFinancial.Domain.Entities;

namespace WebFinancial.Application.ServiceApplication;

public class FaturaService : IFaturaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FaturaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<FaturaDto>> GetAllFaturas()
    {
        try
        {
            var faturas = await _unitOfWork.FaturaPersistence.GetAll();

            if (faturas == null) return null;

            return _mapper.Map<List<FaturaDto>>(faturas);
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FaturaDto> GetFaturaById(int faturaId)
    {
        try
        {
            var fatura = await _unitOfWork.FaturaPersistence.GetById(x => x.Id == faturaId);

            if (fatura == null) return null;

            return _mapper.Map<FaturaDto>(fatura);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FaturaDto> AddFatura(FaturaDto model)
    {
        try
        {
            var fatura = _mapper.Map<Fatura>(model);
            _unitOfWork.FaturaPersistence.Add(fatura);

            if(await _unitOfWork.SaveChangesAsync())
            {
                var result = await _unitOfWork.FaturaPersistence.GetById(x => x.Id == model.Id);
                return _mapper.Map<FaturaDto>(result);
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FaturaDto> UpdateFatura(int faturaId, FaturaDto model)
    {
        try
        {
            if (faturaId != model.Id)
                throw new Exception($"Id {faturaId} inválido.");

            var fatura = await _unitOfWork.FaturaPersistence.GetById(x => x.Id == faturaId);

            if(fatura == null) return null;

            _mapper.Map(model, fatura);

            _unitOfWork.FaturaPersistence.Update(fatura);

            if(await _unitOfWork.SaveChangesAsync())
            {
                var result = await _unitOfWork.FaturaPersistence.GetById(x => x.Id == fatura.Id);
                return _mapper.Map<FaturaDto>(result);
            }

            return null;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteFatura(int faturaId)
    {
        try
        {
           _unitOfWork.FaturaPersistence.Delete(x => x.Id == faturaId);

            return await _unitOfWork.SaveChangesAsync();
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
}
