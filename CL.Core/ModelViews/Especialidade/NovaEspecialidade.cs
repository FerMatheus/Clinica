using System.ComponentModel.DataAnnotations;

namespace CL.Core.ModelViews.Especialidade;

public class NovaEspecialidade
{
    [Required(ErrorMessage ="O nome da Especialidade é obrigatório")]
    public string Descricao { get; set; }
}
