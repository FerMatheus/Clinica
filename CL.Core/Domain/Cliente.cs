namespace CL.Core.Domain;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public char Sexo { get; set; }
    public string Telefone { get; set; }
    public string Documento { get; set; }
    public DateTime Criacao { get; set; }
    public DateTime UltimaAtualizacao { get; set; }
}
