# Lojinha do MVP Conf 2026

API mínima em ASP.NET Core (.NET 10 LTS) que vende camisetas, canecas e adesivos do evento. É a demo da palestra "GitHub Copilot além do autocomplete". Não há banco de dados de propósito: catálogo e pedidos vivem em memória.

## Estrutura

- `demo/Loja.Api/Program.cs`: os endpoints (`GET /produtos`, `GET /pedidos/{id}`, `POST /pedidos`).
- `demo/Loja.Api/Modelos/`: `Produto`, `Pedido`, `ItemPedido`, `NovoPedido`.
- `demo/Loja.Api/Servicos/Catalogo.cs`: produtos e estoque em memória.
- `demo/Loja.Api/Servicos/ServicoDePedidos.cs`: as regras de negócio (cupom, frete, estoque).
- `demo/Loja.Api.Tests/`: testes xUnit.

## Comandos

- Compilar: `dotnet build demo/Loja.Api`
- Testar: `dotnet test demo/Loja.Api.Tests`
- Rodar: `dotnet run --project demo/Loja.Api --launch-profile http` (porta 5020)

## Regras de negócio (a fonte da verdade é o comentário em `ServicoDePedidos.cs`)

- Cupom `MVPCONF10`: 10% de desconto sobre o subtotal. Qualquer outro cupom é inválido.
- Frete: grátis acima de R$ 100,00 de subtotal; até esse valor, R$ 25,00.
- Não vendemos o que não tem em estoque. Erros de validação viram `ArgumentException` (HTTP 400) e falta de estoque vira `InvalidOperationException` (HTTP 409).

## Convenções

- Código, nomes, comentários e mensagens de erro em **português do Brasil**, sem acento em identificadores (`Catalogo`, `ServicoDePedidos`), com acento em textos.
- Responda sempre em português do Brasil.
- Valores monetários são `decimal`, nunca `double`. Arredonde com `Math.Round(valor, 2)` ao calcular descontos.
- Prefira `record` para dados imutáveis e minimal APIs a controllers. Não adicione pacotes NuGet sem avisar.
- Testes: xUnit, um arquivo por classe testada, nomes `Metodo_Cenario_ResultadoEsperado` (ex.: `Criar_SubtotalDeExatamente200_TemFreteGratis`), padrão Arrange/Act/Assert, sem mocks (o `Catalogo` em memória serve de dublê).
- Toda mudança em regra de negócio vem com teste. Rode `dotnet test` antes de dizer que terminou e mostre o resultado.
- Não altere `global.json` nem a versão do .NET.
