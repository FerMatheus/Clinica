using AutoMapper;
using CL.Core.Domain;
using CL.Core.ModelViews.Medico;
using CL.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Implementation;

public class MedicoManager : IMedicoManager
{
    private readonly IMedicoRepository medicoRepository;
    private readonly IMapper mapper;

    public MedicoManager(IMedicoRepository medicoRepository, IMapper mapper)
    {
        this.medicoRepository = medicoRepository;
        this.mapper = mapper;
    }
    public async Task DeleteMedicoAsync(int id)
    {
        await medicoRepository.DeleteMedicoAsync(id);
    }

    public async Task<MedicoView> GetMedicoAsync(int id)
    {
        return mapper.Map<MedicoView>(await medicoRepository.GetMedicoAsync(id));
    }

    public async Task<IEnumerable<MedicoView>> GetMedicosAsync()
    {
        return mapper.Map<IEnumerable<Medico>,IEnumerable<MedicoView>>(await medicoRepository.GetMedicosAsync());
    }

    public async Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico)
    {
        var medico = mapper.Map<Medico>(novoMedico);
        return mapper.Map<MedicoView>(await medicoRepository.InsertMedicoAsync(medico));
    }

    public async Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico)
    {
        var medico = mapper.Map<Medico>(alteraMedico);
        return mapper.Map<MedicoView>(await medicoRepository.UpdateMedicoAsync(medico));
    }
}
