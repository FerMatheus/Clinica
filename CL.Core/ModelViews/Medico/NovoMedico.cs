using CL.Core.ModelViews.Especialidade;

namespace CL.Core.ModelViews.Medico;

public class NovoMedico
{
    public string Nome { get; set; }
    public int CRM { get; set; }
    public ICollection<ReferenceEspecialidade> Especialidades { get; set; }
}
