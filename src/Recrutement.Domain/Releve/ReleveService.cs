using Recrutement.Domain.Abstractions;
using Recrutement.Domain.Patrimoine;
using Index = Recrutement.Domain.Releve.Models.Index;

namespace Recrutement.Domain.Releve;

public class ReleveService : IReleveService
{
    private readonly IReleveRepository _releveRepository;
    private readonly IPatrimoineRepository _patrimoineRepository;

    public ReleveService(IReleveRepository releveRepository, IPatrimoineRepository patrimoineRepository)
    {
        _releveRepository = releveRepository;
    }


    public async Task<IList<Index>> GetAllIndexAsync()
    {
        return await _releveRepository.GetAllIndexesAsync();
    }

    public async Task<IList<Index>> GetIndexCompteurAsync(Guid compteurId)
    {
        var exists = await _patrimoineRepository.CompteurExistsAsync(compteurId);
        if (!exists) throw new InvalidOperationException($"Le compteur {compteurId} n'existe pas");

        return await _releveRepository.GetIndexesByCompteurAsync(compteurId);
    }
}