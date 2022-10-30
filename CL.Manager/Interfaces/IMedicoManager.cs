using CL.Core.ModelViews.Medico;

namespace CL.Manager.Interfaces;

public interface IMedicoManager
{
    Task<IEnumerable<MedicoView>> GetMedicosAsync();
    Task<MedicoView> GetMedicoAsync(int id);
    Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico);
    Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico);
    Task DeleteMedicoAsync(int id);
}
