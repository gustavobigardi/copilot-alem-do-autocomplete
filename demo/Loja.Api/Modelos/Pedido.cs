namespace Loja.Api.Modelos;

public record ItemPedido(int ProdutoId, string Nome, int Quantidade, decimal PrecoUnitario)
{
    public decimal Total => Quantidade * PrecoUnitario;
}

public class Pedido
{
    public int Id { get; init; }
    public string Cliente { get; init; } = "";
    public List<ItemPedido> Itens { get; init; } = [];
    public decimal Subtotal { get; init; }
    public decimal Desconto { get; init; }
    public decimal Frete { get; init; }
    public decimal Total { get; init; }
    public string Status { get; set; } = "Confirmado";
    public DateTime CriadoEm { get; init; } = DateTime.UtcNow;
}

public record NovoItem(int ProdutoId, int Quantidade);

public record NovoPedido(string Cliente, List<NovoItem> Itens, string? Cupom = null);
