public class Personal
{
    public int Id { get; set; }
    
    public string? Nome { get; set; }

    public string? Email { get; set;}

    public string? Especialidade { get; set;}

    public string? Cref { get; set;}

    public string? Alunos { get; set;}

    //Relacionamento muitos para muitos
    //public List<Treino>? Treinos { get; set;}

    //Relacionamento muitos para 1
    //public Usuario? Usuario { get; set; }
}