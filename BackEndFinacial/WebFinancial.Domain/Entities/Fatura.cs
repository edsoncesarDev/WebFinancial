namespace WebFinancial.Domain.Entities;

public class Fatura
{
    public int Id { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime DataFechamento { get; set; }
    public string StatusFatura { get; set; }
    public decimal Valor { get; set; }
    public IEnumerable<Compra> Compras { get; set; }
}
