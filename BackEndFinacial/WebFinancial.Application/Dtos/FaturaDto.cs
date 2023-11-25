
namespace WebFinancial.Application.Dtos;

public class FaturaDto
{
    public int Id { get; set; }
    public string DataAbertura { get; set; }
    public string DataFechamento { get; set; }
    public string StatusFatura { get; set; }
    public string Valor { get; set; }
    //public IEnumerable<CompraDto> Compras { get; set; }
}
