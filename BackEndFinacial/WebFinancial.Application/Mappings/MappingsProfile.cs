
using AutoMapper;
using WebFinancial.Application.Dtos;
using WebFinancial.Domain.Entities;

namespace WebFinancial.Application.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<Fatura, FaturaDto>().ReverseMap();
        CreateMap<Compra, CompraDto>().ReverseMap();
    }
}
