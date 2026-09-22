using Loja.Api.Modelos;

namespace Loja.Api.Servicos;

/// <summary>Catálogo em memória da lojinha do MVP Conf. Sem banco de propósito.</summary>
public class Catalogo
{
    private readonly Dictionary<int, Produto> _produtos = new()
    {
        [1] = new(1, "Camiseta MVP Conf 2026", 80.00m, 50),
        [2] = new(2, "Caneca MVP Conf 2026", 45.00m, 20),
        [3] = new(3, "Adesivos (pacote com 10)", 15.00m, 200),
        [4] = new(4, "Moletom MVP Conf 2026", 199.90m, 10),
        [5] = new(5, "Garrafa térmica", 110.00m, 0),
    };

    public IEnumerable<Produto> Listar() => _produtos.Values.OrderBy(p => p.Id);

    public Produto? Obter(int id) => _produtos.GetValueOrDefault(id);

    public void BaixarEstoque(int id, int quantidade)
    {
        var p = _produtos[id];
        _produtos[id] = p with { Estoque = p.Estoque - quantidade };
    }
}
