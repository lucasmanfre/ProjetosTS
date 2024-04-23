using Microsoft.EntityFrameworkCore;

public static class AvaliacoesFisicaApi
{

    public static void MapAvaliacoesFisicaApi(this WebApplication app)
    {

        var group = app.MapGroup("/AvaliacoesFisica");

        group.MapGet("/", async (BancoDeDados db) =>

            await db.Avaliacoes.ToListAsync()

        );

        group.MapPost("/", async (AvaliacaoFisica avaliacao, BancoDeDados db) =>
        {
            db.Avaliacoes.Add(avaliacao);

            await db.SaveChangesAsync();

            return Results.Created($"/AvaliacoesFisica/{avaliacao.Id}", avaliacao);
        }
        );

        group.MapPut("/{id}", async (int id, AvaliacaoFisica avaliacaoAlterada, BancoDeDados db) =>
         {
             var avaliacao = await db.Avaliacoes.FindAsync(id);

         }
        );





    }



}