using Microsoft.EntityFrameworkCore;

public static class NutricionistasApi{

    public static void MapDietasApi(this WebApplication app){

        var group = app.MapGroup("/Dietas");

        group.MapGet("/", async (BancoDeDados db) =>

            await db.Dietas.ToListAsync()

        );

        group.MapPost("/", async (Dieta dieta, BancoDeDados db) =>
        {
            db.Dietas.Add(dieta);

            await db.SaveChangesAsync();

            return Results.Created($"/Dietas/{dieta.Id}", dieta);
        }
        );

        group.MapPut("/{id}", async (int id, Dieta dietaAlterada, BancoDeDados db) =>
         {

            //select * from avaliacao where id = ?
            var avaliacao = await db.Dietas.FindAsync(id);
            if (avaliacao is null)
            {
                return Results.NotFound();
            }
            avaliacao.Id = dietaAlterada.Id;
            avaliacao.Nome = dietaAlterada.Nome;
            avaliacao.Descricao = dietaAlterada.Descricao;
            avaliacao.Calorias = dietaAlterada.Calorias;
            avaliacao.Proteinas = dietaAlterada.Proteinas;
            avaliacao.Carboidratos = dietaAlterada.Carboidratos;
            avaliacao.Gorduras = dietaAlterada.Gorduras;
            avaliacao.RestricoesAlimentares = dietaAlterada.RestricoesAlimentares;
            avaliacao.HistoricoDietas = dietaAlterada.HistoricoDietas;

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();

         }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Dietas.FindAsync(id) is Dieta dieta)
            {
                //Operações de exclusão
                db.Dietas.Remove(dieta);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );

    }

}