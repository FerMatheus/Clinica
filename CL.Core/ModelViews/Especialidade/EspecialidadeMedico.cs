using CL.Core.ModelViews.Medico;

namespace CL.Core.ModelViews.Especialidade
{
    public class EspecialidadeMedico : EspecialidadeView
    {
        public ICollection<MedicoEspecialidade> Medicos { get; set; }
    }
}