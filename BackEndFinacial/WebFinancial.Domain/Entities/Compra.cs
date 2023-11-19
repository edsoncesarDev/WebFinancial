namespace WebFinancial.Domain.Entities;

public class Compra
{
    public int Id { get; set; }
    public DateTime DataCompra { get; set; }
    public int Parcelas { get; set; }
    public string TipoPagamento { get; set; }
    public decimal Valor { get; set; }
    public int FaturaId { get; set; }
    public Fatura Fatura { get; set; }
}
