using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

public static class UsuariosApi{

    public static void MapUsuariosApi(this WebApplication app){

        var group = app.MapGroup("/Usuarios");

        group.MapGet("/", async (BancoDeDados db) =>
        {
            await db.Usuarios.ToListAsync();
        }

        );

        group.MapPost("/", async (Usuario usuario, BancoDeDados db) =>
        {
            db.Usuarios.Add(usuario);

            await db.SaveChangesAsync();

            return Results.Created($"/Usuarios/{usuario.Id}", usuario);
        }
        );

        group.MapPut("/{id}", async (int id, Usuario usuarioAlterada, BancoDeDados db) =>
         {

            //select * from avaliacao where id = ?
            var Usuario = await db.Usuarios.FindAsync(id);
            if (Usuario is null)
            {
                return Results.NotFound();
            }
            Usuario.Id = usuarioAlterada.Id;
            Usuario.Nome = usuarioAlterada.Nome;
            Usuario.Idade = usuarioAlterada.Idade;
            Usuario.Email = usuarioAlterada.Email;
            Usuario.Peso = usuarioAlterada.Peso;
            Usuario.Sexo = usuarioAlterada.Sexo;
            Usuario.NivelAtividadeFisica = usuarioAlterada.NivelAtividadeFisica;
            Usuario.HistoricoMedico = usuarioAlterada.HistoricoMedico;
            Usuario.ObjetivoSaude = usuarioAlterada.ObjetivoSaude;
            //Usuario.PlanoAlimentar = usuarioAlterada.PlanoAlimentar;
            //Usuario.PlanoTreino = usuarioAlterada.PlanoTreino;

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();

         }
        );

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Usuarios.FindAsync(id) is Usuario usuario)
            {
                //Operações de exclusão
                db.Usuarios.Remove(usuario);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );

    }

}