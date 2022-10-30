using CL.Core.ModelViews.Especialidade;

namespace CL.Core.ModelViews.Medico;
/// <summary>
/// Objeto que servirá para colher dados do médico a ser cadastrado
/// </summary>
public class NovoMedico
{
    /// <summary>
    /// Nome do médico
    /// </summary>
    /// <example>Roberto Celestino</example>
    public string Nome { get; set; }
    /// <summary>
    /// ´Número do CRM do médico
    /// </summary>
    /// <example>123</example>
    public int CRM { get; set; }
    /// <summary>
    /// Os ids das especialidades que o médico possue.
    /// </summary>
    public ICollection<ReferenceEspecialidade> Especialidades { get; set; }
}
