---
applyTo: "demo/Loja.Api.Tests/**/*.cs"
---

Testes da Lojinha: xUnit puro, sem mocks e sem pacotes extras. Cada teste instancia um `Catalogo` novo e um `ServicoDePedidos` novo (o catálogo em memória é o dublê). Use `Assert.Equal` com `decimal` literal (`200m`), nunca `double`. Nome do método: `Metodo_Cenario_ResultadoEsperado`. Um `// Arrange`, `// Act`, `// Assert` por teste.
