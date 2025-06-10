namespace Domain.Entities;

public enum TipoOperacao
{
    Compra,
    Venda
}

public class Operacao
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int AtivoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public TipoOperacao Tipo { get; set; }
    public decimal Corretagem { get; set; }
    public DateTime DataHora { get; set; }
}
