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

            //select * from avaliacao where id = ?
            var avaliacao = await db.Avaliacoes.FindAsync(id);
            if (avaliacao is null)
            {
                return Results.NotFound();
            }
            avaliacao.Id = avaliacaoAlterada.Id;
            avaliacao.Data = avaliacaoAlterada.Data;
            avaliacao.Altura = avaliacaoAlterada.Altura;
            avaliacao.Peso = avaliacaoAlterada.Peso;
            avaliacao.CircunferenciaCintura = avaliacaoAlterada.CircunferenciaCintura;
            avaliacao.PercentualGordura = avaliacaoAlterada.PercentualGordura;
            avaliacao.MassaMuscular = avaliacaoAlterada.MassaMuscular;
            avaliacao.PressaoArterial = avaliacaoAlterada.PressaoArterial;
            avaliacao.FrequenciaCardiaca = avaliacaoAlterada.FrequenciaCardiaca;

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();

         }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Avaliacoes.FindAsync(id) is AvaliacaoFisica avaliacao)
            {
                //Operações de exclusão
                db.Avaliacoes.Remove(avaliacao);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );




    }



}