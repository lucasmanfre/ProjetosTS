using Microsoft.EntityFrameworkCore;

public static class TreinosApi{

    public static void MapTreinosApi(this WebApplication app){

        var group = app.MapGroup("/Treinos");

        group.MapGet("/", async (BancoDeDados db) =>

            await db.Treinos.ToListAsync()

        );

        group.MapPost("/", async (Treino treino, BancoDeDados db) =>
        {
            db.Treinos.Add(treino);

            await db.SaveChangesAsync();

            return Results.Created($"/Treinos/{treino.Id}", treino);
        }
        );

        group.MapPut("/{id}", async (int id, Treino treinoAlterada, BancoDeDados db) =>
         {

            //select * from avaliacao where id = ?
            var Treino = await db.Treinos.FindAsync(id);
            if (Treino is null)
            {
                return Results.NotFound();
            }
            Treino.Id = treinoAlterada.Id;
            Treino.Nome = treinoAlterada.Nome;
            Treino.Descricao = treinoAlterada.Descricao;
            Treino.Tipo = treinoAlterada.Tipo;
            Treino.Objetivo = treinoAlterada.Objetivo;
            Treino.Refeicoes = treinoAlterada.Refeicoes;
            Treino.Lanches = treinoAlterada.Lanches;
            Treino.Receitas = treinoAlterada.Receitas;

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();

         }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Treinos.FindAsync(id) is Treino treino)
            {
                //Operações de exclusão
                db.Treinos.Remove(treino);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );

    }

}