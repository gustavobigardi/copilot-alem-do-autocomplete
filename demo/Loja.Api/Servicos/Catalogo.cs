using Loja.Api.Modelos;

namespace Loja.Api.Servicos;

/// <summary>Catálogo em memória da lojinha do MVP Conf. Sem banco de propósito.</summary>
public class Catalogo
{
    private readonly Dictionary<int, Produto> _produtos;

    public Catalogo() : this(
        [
            new Produto(1, "Camiseta MVP Conf 2026", 80.00m, 50),
            new Produto(2, "Caneca MVP Conf 2026", 45.00m, 20),
            new Produto(3, "Adesivos (pacote com 10)", 15.00m, 200),
            new Produto(4, "Moletom MVP Conf 2026", 199.90m, 10),
            new Produto(5, "Garrafa térmica", 110.00m, 0),
        ])
    {
    }

    public Catalogo(IEnumerable<Produto> produtos)
    {
        if (produtos is null)
            throw new ArgumentException("Informe os produtos do catálogo.");

        _produtos = [];
        foreach (var produto in produtos)
        {
            if (_produtos.ContainsKey(produto.Id))
                throw new ArgumentException($"Produto duplicado no catálogo: {produto.Id}.");

            _produtos[produto.Id] = produto;
        }
    }

    public IEnumerable<Produto> Listar() => _produtos.Values.OrderBy(p => p.Id);

    public Produto? Obter(int id) => _produtos.GetValueOrDefault(id);

    public void BaixarEstoque(int id, int quantidade)
    {
        var p = _produtos[id];
        _produtos[id] = p with { Estoque = p.Estoque - quantidade };
    }
}
