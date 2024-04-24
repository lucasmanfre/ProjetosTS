using Microsoft.EntityFrameworkCore;

public static class PlanosAlimentaresApi{

    public static void MapPlanosAlimentaresApi(this WebApplication app){

        var group = app.MapGroup("/PlanosAlimentares");

        group.MapGet("/", async (BancoDeDados db) =>

            await db.Planos.ToListAsync()

        );

        group.MapPost("/", async (PlanoAlimentar plano, BancoDeDados db) =>
        {
            db.Planos.Add(plano);

            await db.SaveChangesAsync();

            return Results.Created($"/PlanosAlimentares/{plano.Id}", plano);
        }
        );

        group.MapPut("/{id}", async (int id, PlanoAlimentar planoAlterada, BancoDeDados db) =>
         {

            //select * from avaliacao where id = ?
            var Plano = await db.Planos.FindAsync(id);
            if (Plano is null)
            {
                return Results.NotFound();
            }
            Plano.Id = planoAlterada.Id;
            Plano.Nome = planoAlterada.Nome;
            Plano.Descricao = planoAlterada.Descricao;
            Plano.Tipo = planoAlterada.Tipo;
            Plano.Objetivo = planoAlterada.Objetivo;
            Plano.Refeicoes = planoAlterada.Refeicoes;
            Plano.Lanches = planoAlterada.Lanches;
            Plano.Receitas = planoAlterada.Receitas;

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();

         }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Planos.FindAsync(id) is PlanoAlimentar plano)
            {
                //Operações de exclusão
                db.Planos.Remove(plano);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );

    }

}