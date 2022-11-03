using System.ComponentModel.DataAnnotations;

namespace CL.Core.ModelViews.Especialidade;

public class NovaEspecialidade
{
    [Required(ErrorMessage = "O nome da Especialidade é obrigatório")]
    [StringLength(15, MinimumLength =5, ErrorMessage = "O tamanho mínimo é de 5 caracteres")]
    public string Descricao { get; set; }
}
