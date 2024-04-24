using Microsoft.EntityFrameworkCore;

public static class NutricionistasApi{

    public static void MapNutrionistasApi(this WebApplication app){

        var group = app.MapGroup("/Nutricionistas");

        group.MapGet("/", async (BancoDeDados db) =>

            await db.Nutricionistas.ToListAsync()

        );

        group.MapPost("/", async (Nutricionista nutricionista, BancoDeDados db) =>
        {
            db.Nutricionistas.Add(nutricionista);

            await db.SaveChangesAsync();

            return Results.Created($"/Nutricionistas/{nutricionista.Id}", nutricionista);
        }
        );

        group.MapPut("/{id}", async (int id, Nutricionista nutricionistaAlterada, BancoDeDados db) =>
         {

            //select * from avaliacao where id = ?
            var nutricionista = await db.Nutricionistas.FindAsync(id);
            if (nutricionista is null)
            {
                return Results.NotFound();
            }
            nutricionista.Id = nutricionistaAlterada.Id;
            nutricionista.Nome = nutricionistaAlterada.Nome;
            nutricionista.Email = nutricionistaAlterada.Email;
            nutricionista.Especialidade = nutricionistaAlterada.Especialidade;
            nutricionista.Crm = nutricionistaAlterada.Crm;
            nutricionista.Pacientes = nutricionistaAlterada.Pacientes;
            nutricionista.Dietas = nutricionistaAlterada.Dietas;

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();

         }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Nutricionistas.FindAsync(id) is Nutricionista nutricionista)
            {
                //Operações de exclusão
                db.Nutricionistas.Remove(nutricionista);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );

    }

}