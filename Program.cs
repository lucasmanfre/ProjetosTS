using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BancoDeDados>();

var app = builder.Build();



app.MapGet("/", () => "Olá Mundo.balala");

app.MapGet("/Usuario/{Id}", async (int id, BancoDeDados db) =>
{
    // select * from tarefas t where t.Id = ?
    return await db.Usuarios.FindAsync(id) is Usuario usuario ? Results.Ok(usuario) : Results.NotFound();
});


app.MapPost("/Usuario", async (Usuario usuario, BancoDeDados db) =>
{
    db.Usuarios.Add(usuario);

    // insert into ...
    await db.SaveChangesAsync();

    return Results.Created($"/Usuario/{usuario.Id}", usuario);
});


app.Run();
