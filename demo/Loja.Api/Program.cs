using Loja.Api.Modelos;
using Loja.Api.Servicos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Catalogo>();
builder.Services.AddSingleton<ServicoDePedidos>();

var app = builder.Build();

app.MapGet("/", () => "Lojinha do MVP Conf 2026. Veja /produtos e /pedidos/{id}.");

app.MapGet("/produtos", (Catalogo catalogo) => catalogo.Listar());

app.MapGet("/pedidos/{id:int}", (int id, ServicoDePedidos pedidos) =>
    pedidos.Obter(id) is { } pedido ? Results.Ok(pedido) : Results.NotFound());

app.MapPost("/pedidos", (NovoPedido novo, ServicoDePedidos pedidos) =>
{
    try
    {
        var pedido = pedidos.Criar(novo);
        return Results.Created($"/pedidos/{pedido.Id}", pedido);
    }
    catch (ArgumentException e)
    {
        return Results.BadRequest(new { erro = e.Message });
    }
    catch (InvalidOperationException e)
    {
        return Results.Conflict(new { erro = e.Message });
    }
});

app.Run();
