namespace CL.Core.ModelViews.Cliente;
/// <summary>
/// Objetor para fazer a coleta seletiva dos dados do cliente.
/// </summary>
public class NovoCliente
{
    /// <summary>
    /// Nome do cliente
    /// </summary>
    /// <example>Matheus Fernandes</example>
    public string Nome { get; set; }
    /// <summary>
    /// Data de nascimento do usuário
    /// </summary>
    /// <example>1998-03-25</example>
    public DateTime Nascimento { get; set; }
    /// <summary>
    /// Sexo do cliente
    /// </summary>
    /// <example>M, F, ou N</example>
    public char Sexo { get; set; }
    /// <summary>
    /// Número de contato do cliente
    /// </summary>
    /// <example>85-992346698</example>
    public string Telefone { get; set; }
    /// <summary>
    /// Documento que será vinculado ao usuário
    /// </summary>
    /// <example>Pode ser RG, CPF ou CNH</example>
    public string Documento { get; set; }
}
