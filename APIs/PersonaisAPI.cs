using Microsoft.EntityFrameworkCore;

public static class PersonaisApi{

    public static void MapPersonaisApi(this WebApplication app){

        var group = app.MapGroup("/Personais");

        group.MapGet("/", async (BancoDeDados db) =>
            {    
            return await db.Personais.ToListAsync();
            }
        );

        group.MapPost("/", async (Personal personal, BancoDeDados db) =>
        {
            db.Personais.Add(personal);

            await db.SaveChangesAsync();

            return Results.Created($"/Personais/{personal.Id}", personal);
        }
        );

        group.MapPut("/{id}", async (int id, Personal personalAlterada, BancoDeDados db) =>
         {

            //select * from avaliacao where id = ?
            var Personal = await db.Personais.FindAsync(id);
            if (Personal is null)
            {
                return Results.NotFound();
            }
            Personal.Id = personalAlterada.Id;
            Personal.Nome = personalAlterada.Nome;
            Personal.Email = personalAlterada.Email;
            Personal.Especialidade = personalAlterada.Especialidade;
            Personal.Cref = personalAlterada.Cref;
            Personal.Alunos = personalAlterada.Alunos;
            //Personal.Treinos = personalAlterada.Treinos;

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();

         }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Personais.FindAsync(id) is Personal personal)
            {
                //Operações de exclusão
                db.Personais.Remove(personal);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );

    }

}