using Loja.Api.Modelos;
using Loja.Api.Servicos;
using Xunit;

namespace Loja.Api.Tests;

public class CatalogoTests
{
    [Fact]
    public void Criar_ComProdutoDuplicado_LancaArgumentException()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new(1, "Produto A", 10m, 1),
            new(1, "Produto B", 20m, 2),
        };

        // Act
        var excecao = Assert.Throws<ArgumentException>(() => new Catalogo(produtos));

        // Assert
        Assert.Equal("Produto duplicado no catálogo: 1.", excecao.Message);
    }
}
