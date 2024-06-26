using Microsoft.EntityFrameworkCore;

public class BancoDeDados : DbContext
{

    public BancoDeDados(DbContextOptions<BancoDeDados> options)
       : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=projeto;user=root;password=positivo");
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Nutricionista> Nutricionistas { get; set; }
    public DbSet<Personal> Personais { get; set; }
    public DbSet<Dieta> Dietas { get; set; }
    public DbSet<PlanoAlimentar> Planos { get; set; }
    public DbSet<Treino> Treinos { get; set; }
    public DbSet<AvaliacaoFisica> Avaliacoes { get; set; }



}