# GitHub Copilot além do autocomplete: como desenvolver com chat, agentes e contexto compartilhado

Materiais da palestra apresentada no **MVP Conf 2026** (São Paulo, 26 de setembro de 2026) por Gustavo Bigardi.

> Nesta sessão, o foco é sair do uso básico do Copilot e explorar fluxos modernos de engenharia assistida por IA: geração guiada, refatoração, investigação de código, criação de testes e aceleração de tarefas reais do dia a dia. A palestra também discute limites, riscos e como extrair valor com prompts, contexto e revisão humana.

## A mensagem em uma frase

O Copilot é tão bom quanto o contexto que você dá a ele, e tão seguro quanto a revisão que você faz depois.

## Conteúdo

| Pasta/arquivo | O que é |
|---|---|
| [`slides.pdf`](slides.pdf) | Slides da palestra |
| [`demo/Loja.Api/`](demo/Loja.Api) | A Lojinha do MVP Conf: uma API mínima em .NET 10 com catálogo, estoque e pedidos em memória. É o código que o Copilot investiga, testa e altera nas demos |
| [`demo/Loja.Api.Tests/`](demo/Loja.Api.Tests) | Os testes xUnit que o Copilot gerou na Demo 2, a partir das convenções do repositório. Foram eles que revelaram o bug do frete |
| [`.github/copilot-instructions.md`](.github/copilot-instructions.md) | As instruções do repositório: o que a Lojinha é, como compilar e testar, as regras de negócio e as convenções (nomes em português, `decimal`, testes com nome `Metodo_Cenario_Resultado`) |
| [`.github/instructions/`](.github/instructions) | Instrução que só vale para os arquivos de teste (`applyTo`) |
| [`.github/agents/revisor.agent.md`](.github/agents/revisor.agent.md) | Um agente custom que só lê e critica: revisa uma mudança contra as regras de negócio e diz "Aprovo" ou "Não aprovo" |
| [`.github/skills/nova-regra-de-negocio/`](.github/skills/nova-regra-de-negocio) | Uma skill: o passo a passo (teste primeiro) que o Copilot carrega quando alguém pede uma regra nova |
| [`.github/mcp.json`](.github/mcp.json) | O servidor MCP do Microsoft Learn, para o Copilot consultar a documentação oficial em vez de inventar |
| [`.github/workflows/copilot-setup-steps.yml`](.github/workflows/copilot-setup-steps.yml) | Prepara o ambiente do Copilot cloud agent (o agente que trabalha na nuvem a partir de uma issue) com o SDK do .NET 10 |
| [`referencias.md`](referencias.md) | Fontes, conferidas na documentação de setembro de 2026 |

## A Lojinha

Três endpoints e uma classe de regras. Sem banco de dados de propósito: a palestra é sobre o Copilot, não sobre persistência.

| Endpoint | O que faz |
|---|---|
| `GET /produtos` | Lista o catálogo (camiseta, caneca, adesivos, moletom e uma garrafa sem estoque) |
| `POST /pedidos` | Cria um pedido: valida, aplica o cupom `MVPCONF10`, calcula o frete e baixa o estoque |
| `GET /pedidos/{id}` | Consulta um pedido |

As regras estão no comentário no topo de [`ServicoDePedidos.cs`](demo/Loja.Api/Servicos/ServicoDePedidos.cs). Na branch `demo-inicio` uma delas está errada de propósito: o frete grátis deveria valer **a partir de** R$ 200,00, mas o código usa `>`. Um pedido de exatamente R$ 200,00 (camiseta + 2 canecas + 2 pacotes de adesivos) paga frete. É o bug que o Copilot encontra na Demo 1, que os testes gerados na Demo 2 provam, e que é corrigido na Demo 3 seguindo as instruções do repositório. Na `main` o bug já está corrigido.

## As demos

| Demo | Onde | O que mostra |
|---|---|---|
| 1. Investigar | GitHub Copilot app | "O que este projeto faz e onde é calculado o frete?" O Copilot lê o código, explica e aponta que o código não bate com o comentário |
| 2. Testar | GitHub Copilot app | Uma sessão do agente cria o projeto de testes, roda `dotnet test` e mostra o teste que falha |
| 3. Contexto compartilhado | GitHub Copilot app | Corrigir o bug com as instruções, a skill e o agente `revisor`; consultar o Learn pelo MCP |
| 4. Delegar | GitHub.com | Uma issue ("cancelar pedido") entregue ao Copilot cloud agent, que abre um PR revisado pelo Copilot code review |

## Como rodar

Pré-requisito: [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (o `global.json` fixa o 10.0.400 ou superior na mesma linha).

```bash
dotnet run --project demo/Loja.Api --launch-profile http
```

A API sobe em `http://localhost:5020`. Os exemplos de requisição estão em [`demo/Loja.Api/Loja.Api.http`](demo/Loja.Api/Loja.Api.http). Para os testes:

```bash
dotnet test demo/Loja.Api.Tests
```

Para reproduzir as demos com o GitHub Copilot CLI (o app e o CLI usam o mesmo motor e os mesmos arquivos de contexto):

```bash
git checkout demo-inicio
copilot
```

Dentro da sessão: `/agent revisor` para trocar de agente; `copilot instruction list`, `copilot skill list` e `copilot mcp list` (fora da sessão) mostram o que o repositório está ensinando ao Copilot.

## Avisos

- Os arquivos de contexto (`.github/*`) são o "leve para casa". Copie a ideia, não o conteúdo: escreva o que é verdade sobre o **seu** repositório.
- O Copilot cloud agent e o code review precisam do repositório no GitHub e consomem AI Credits e minutos do Actions. Confira o seu plano antes de sair delegando issues.
- Tudo o que o Copilot gera passa por revisão humana antes de virar commit. Essa é a metade da palestra que não está no código.
