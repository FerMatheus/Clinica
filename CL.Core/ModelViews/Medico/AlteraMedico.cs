namespace CL.Core.ModelViews.Medico;
/// <summary>
/// Objeto que servirá para atualizar os dados do médico
/// </summary>
public class AlteraMedico : NovoMedico
{
    /// <summary>
    /// Id pertencente ao médico se deseja alterar.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }
}
