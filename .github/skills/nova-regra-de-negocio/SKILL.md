---
name: nova-regra-de-negocio
description: Como adicionar ou alterar uma regra de negócio da Lojinha (cupom, frete, estoque, cancelamento) com teste primeiro. Use quando pedirem uma regra nova, um endpoint novo ou a correção de um cálculo.
---

# Nova regra de negócio na Lojinha

Siga esta ordem. Não pule o passo 1.

1. **Escreva o teste antes.** Crie ou edite o arquivo em `demo/Loja.Api.Tests/` com o nome `Metodo_Cenario_ResultadoEsperado`. Cubra o caso feliz e pelo menos um caso de borda (o limite exato, zero, estoque igual à quantidade).
2. **Rode `dotnet test demo/Loja.Api.Tests`** e confirme que o teste novo falha pelo motivo certo.
3. **Implemente a regra** em `demo/Loja.Api/Servicos/ServicoDePedidos.cs`. Atualize o comentário de regras no topo da classe: ele é a fonte da verdade.
4. Se precisar de endpoint, adicione em `demo/Loja.Api/Program.cs` seguindo o padrão dos existentes (`ArgumentException` → 400, `InvalidOperationException` → 409) e um exemplo em `demo/Loja.Api/Loja.Api.http`.
5. **Rode `dotnet test` de novo** e mostre a saída. Só diga que terminou com todos os testes verdes.
6. Resuma em três linhas: o que mudou, qual teste prova, o que ficou de fora.
