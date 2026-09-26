using Loja.Api.Modelos;
using Loja.Api.Servicos;
using Xunit;

namespace Loja.Api.Tests;

public class ServicoDePedidosTests
{
    [Fact]
    public void Obter_PedidoInexistente_RetornaNulo()
    {
        // Arrange
        var servico = new ServicoDePedidos(new Catalogo());

        // Act
        var pedido = servico.Obter(1);

        // Assert
        Assert.Null(pedido);
    }

    [Fact]
    public void Obter_PedidoCriado_RetornaPedido()
    {
        // Arrange
        var servico = new ServicoDePedidos(new Catalogo());
        var criado = servico.Criar(new NovoPedido("Ana", [new NovoItem(1, 1)]));

        // Act
        var pedido = servico.Obter(criado.Id);

        // Assert
        Assert.Same(criado, pedido);
    }

    [Fact]
    public void Criar_PedidoNormalAbaixoDe200_CobraFrete()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Ana", [new NovoItem(1, 1)]);

        // Act
        var pedido = servico.Criar(novo);

        // Assert
        Assert.Equal(80m, pedido.Subtotal);
        Assert.Equal(25m, pedido.Frete);
        Assert.Equal(105m, pedido.Total);
    }

    [Fact]
    public void Criar_CupomMvpConf10EmMinusculas_AplicaDesconto()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Bruno", [new NovoItem(1, 1)], "mvpconf10");

        // Act
        var pedido = servico.Criar(novo);

        // Assert
        Assert.Equal(8m, pedido.Desconto);
        Assert.Equal(97m, pedido.Total);
    }

    [Fact]
    public void Criar_CupomInvalido_LancaArgumentException()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Carla", [new NovoItem(1, 1)], "DESCONTO");

        // Act
        var excecao = Assert.Throws<ArgumentException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("Cupom inválido.", excecao.Message);
    }

    [Fact]
    public void Criar_ItemSemEstoque_LancaInvalidOperationException()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Diego", [new NovoItem(5, 1)]);

        // Act
        var excecao = Assert.Throws<InvalidOperationException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("Sem estoque suficiente de 'Garrafa térmica'.", excecao.Message);
    }

    [Fact]
    public void Criar_QuantidadeZero_LancaArgumentException()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Elisa", [new NovoItem(1, 0)]);

        // Act
        var excecao = Assert.Throws<ArgumentException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("Quantidade inválida para o produto 1.", excecao.Message);
    }

    [Fact]
    public void Criar_ClienteVazio_LancaArgumentException()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("", [new NovoItem(1, 1)]);

        // Act
        var excecao = Assert.Throws<ArgumentException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("Informe o nome do cliente.", excecao.Message);
    }

    [Fact]
    public void Criar_ClienteComApenasEspacos_LancaArgumentException()
    {
        // Arrange
        var servico = new ServicoDePedidos(new Catalogo());
        var novo = new NovoPedido("   ", [new NovoItem(1, 1)]);

        // Act
        var excecao = Assert.Throws<ArgumentException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("Informe o nome do cliente.", excecao.Message);
    }

    [Fact]
    public void Criar_SemItens_LancaArgumentException()
    {
        // Arrange
        var servico = new ServicoDePedidos(new Catalogo());
        var novo = new NovoPedido("Ana", []);

        // Act
        var excecao = Assert.Throws<ArgumentException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("O pedido precisa ter pelo menos um item.", excecao.Message);
    }

    [Fact]
    public void Criar_ListaDeItensNula_LancaArgumentException()
    {
        // Arrange
        var servico = new ServicoDePedidos(new Catalogo());
        var novo = new NovoPedido("Ana", null!);

        // Act
        var excecao = Assert.Throws<ArgumentException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("O pedido precisa ter pelo menos um item.", excecao.Message);
    }

    [Fact]
    public void Criar_ProdutoInexistente_LancaArgumentException()
    {
        // Arrange
        var servico = new ServicoDePedidos(new Catalogo());
        var novo = new NovoPedido("Ana", [new NovoItem(999, 1)]);

        // Act
        var excecao = Assert.Throws<ArgumentException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("Produto 999 não existe.", excecao.Message);
    }

    [Fact]
    public void Criar_QuantidadeExatamenteIgualAoEstoque_AceitaPedido()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Ana", [new NovoItem(2, 20)]);

        // Act
        var pedido = servico.Criar(novo);

        // Assert
        Assert.Equal(20, pedido.Itens[0].Quantidade);
        Assert.Equal(0, catalogo.Obter(2)!.Estoque);
    }

    [Fact]
    public void Criar_CupomInvalido_NaoBaixaEstoqueNemRegistraPedido()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Ana", [new NovoItem(1, 1)], "DESCONTO");

        // Act
        Assert.Throws<ArgumentException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal(50, catalogo.Obter(1)!.Estoque);
        Assert.Null(servico.Obter(1));
    }

    [Fact]
    public void Criar_QuantidadeDisponivel_BaixaEstoque()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Fátima", [new NovoItem(2, 2)]);

        // Act
        servico.Criar(novo);

        // Assert
        Assert.Equal(18, catalogo.Obter(2)!.Estoque);
    }

    [Fact]
    public void Criar_ProdutoRepetidoComQuantidadeTotalAcimaDoEstoque_RejeitaSemAlterarEstado()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Helena", [new NovoItem(2, 11), new NovoItem(2, 10)]);

        // Act
        var excecao = Assert.Throws<InvalidOperationException>(() => servico.Criar(novo));

        // Assert
        Assert.Equal("Sem estoque suficiente de 'Caneca MVP Conf 2026'.", excecao.Message);
        Assert.Equal(20, catalogo.Obter(2)!.Estoque);
        Assert.Null(servico.Obter(1));
    }

    [Fact]
    public void Criar_SubtotalDeExatamente200_TemFreteGratis()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido(
            "Gustavo",
            [
                new NovoItem(1, 1),
                new NovoItem(2, 2),
                new NovoItem(3, 2),
            ]);

        // Act
        var pedido = servico.Criar(novo);

        // Assert
        Assert.Equal(200m, pedido.Subtotal);
        Assert.Equal(0m, pedido.Frete);
        Assert.Equal(200m, pedido.Total);
    }
}
