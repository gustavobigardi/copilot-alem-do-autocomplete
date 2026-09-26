using Loja.Api.Modelos;

namespace Loja.Api.Servicos;

/// <summary>
/// Regras da loja:
/// - cupom MVPCONF10 dá 10% de desconto sobre o subtotal;
/// - frete grátis acima de R$ 100,00 de subtotal; até esse valor, R$ 25,00;
/// - não vendemos o que não tem em estoque.
/// </summary>
public class ServicoDePedidos(Catalogo catalogo)
{
    private readonly Dictionary<int, Pedido> _pedidos = new();
    private int _proximoId = 1;

    public Pedido? Obter(int id) => _pedidos.GetValueOrDefault(id);

    public Pedido Criar(NovoPedido novo)
    {
        if (string.IsNullOrWhiteSpace(novo.Cliente))
            throw new ArgumentException("Informe o nome do cliente.");
        if (novo.Itens is null || novo.Itens.Count == 0)
            throw new ArgumentException("O pedido precisa ter pelo menos um item.");

        var itens = new List<ItemPedido>();
        decimal subtotal = 0;
        foreach (var item in novo.Itens)
        {
            if (item.Quantidade <= 0)
                throw new ArgumentException($"Quantidade inválida para o produto {item.ProdutoId}.");
            var produto = catalogo.Obter(item.ProdutoId);
            if (produto is null)
                throw new ArgumentException($"Produto {item.ProdutoId} não existe.");
            if (produto.Estoque < item.Quantidade)
                throw new InvalidOperationException($"Sem estoque suficiente de '{produto.Nome}'.");
            itens.Add(new ItemPedido(produto.Id, produto.Nome, item.Quantidade, produto.Preco));
            subtotal = subtotal + produto.Preco * item.Quantidade;
        }

        decimal desconto = 0;
        if (novo.Cupom != null)
        {
            if (novo.Cupom.ToUpper() == "MVPCONF10")
            {
                desconto = Math.Round(subtotal * 0.1m, 2);
            }
            else
            {
                throw new ArgumentException("Cupom inválido.");
            }
        }

        decimal frete;
        if (subtotal > 100m)
        {
            frete = 0;
        }
        else
        {
            frete = 25;
        }

        foreach (var item in itens)
        {
            catalogo.BaixarEstoque(item.ProdutoId, item.Quantidade);
        }

        var pedido = new Pedido
        {
            Id = _proximoId++,
            Cliente = novo.Cliente,
            Itens = itens,
            Subtotal = subtotal,
            Desconto = desconto,
            Frete = frete,
            Total = subtotal - desconto + frete,
        };
        _pedidos[pedido.Id] = pedido;
        return pedido;
    }
}
