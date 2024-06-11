public class Treino
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set;}

    public string? Exercicios { get; set;}

    public int Repeticoes { get; set; }

    public int Series { get; set; }

    public string? Intensidade { get; set;}

    public string? HistoricoTreinos { get; set;}

    //Relacionamento muitos para 1
    //public Usuario? Usuario { get; set; }
    
    //Relacionamento muitos para muitos
    //public List<Personal>? Personais { get; set; }
}