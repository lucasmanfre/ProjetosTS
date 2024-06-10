public class Usuario
{
    public int Id { get; set; }
    
    public string? Nome { get; set; }

    public int Idade { get; set;}

    public string? Email { get; set;}

    public float Peso { get; set;}

    public char? Sexo { get; set;}

    public string? NivelAtividadeFisica { get; set;}

    public string? HistoricoMedico { get; set;}

    public string? ObjetivoSaude { get; set;}

    // Relacionamento 1 para muitos
    public List<PlanoAlimentar>? PlanosAlimentares { get; set;}

    // Relacionamento 1 para muitos
    public List<Treino>? Treinos { get; set;}

    // Relacionamento 1 para muitos
    public List<Personal>? Personais { get; set; }
}