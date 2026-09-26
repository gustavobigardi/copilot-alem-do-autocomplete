using Loja.Api.Modelos;
using Loja.Api.Servicos;
using Xunit;

namespace Loja.Api.Tests;

public class ServicoDePedidosTests
{
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
    public void Criar_SubtotalAcimaDe100_TemFreteGratis()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido(
            "Gustavo",
            [
                new NovoItem(2, 2),
                new NovoItem(3, 2),
            ]);

        // Act
        var pedido = servico.Criar(novo);

        // Assert
        Assert.Equal(120m, pedido.Subtotal);
        Assert.Equal(0m, pedido.Frete);
        Assert.Equal(120m, pedido.Total);
    }

    [Fact]
    public void Criar_SubtotalAte100_CobraFrete()
    {
        // Arrange
        var catalogo = new Catalogo();
        var servico = new ServicoDePedidos(catalogo);
        var novo = new NovoPedido("Helena", [new NovoItem(2, 2)]);

        // Act
        var pedido = servico.Criar(novo);

        // Assert
        Assert.Equal(90m, pedido.Subtotal);
        Assert.Equal(25m, pedido.Frete);
        Assert.Equal(115m, pedido.Total);
    }
}
