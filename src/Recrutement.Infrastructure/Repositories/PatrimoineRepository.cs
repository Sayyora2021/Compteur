using Microsoft.EntityFrameworkCore;
using Recrutement.Domain.Patrimoine;
using Recrutement.Domain.Patrimoine.Models;
using Recrutement.Infrastructure.Repositories.Entities;

namespace Recrutement.Infrastructure.Repositories;

public class PatrimoineRepository : IPatrimoineRepository
{
    private readonly DataContext _dataContext;

    public PatrimoineRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IList<Compteur>> GetAllCompteursAsync()
    {
        var all = await _dataContext.Appareils.ToListAsync();

        return all
            .Where(x => x.Type.Equals("Compteur"))
            .Select(a => new Compteur(a.Id, a.NumeroSerie, a.DatePose.DateTime))
            .ToList();
    }

   
    public async Task<bool> CompteurExistsAsync(Guid compteurId)
    {
        var compteur = await _dataContext.Appareils.FindAsync(compteurId);
        return compteur != null;
    }

    public async Task CreateCompteurAsync(string numeroSerie)
    {
        var appareil = new Appareil
        {
            NumeroSerie = numeroSerie,
            Type= "Compteur"
        };

        _dataContext.Appareils.Add(appareil);
        await _dataContext.SaveChangesAsync();

    }

    public async Task DeleteCompteurAsync(Guid appareilId)
    {
        var appareil = await _dataContext.Appareils.FindAsync(appareilId);
        if (appareil != null)
        {
            _dataContext.Appareils.Remove(appareil);
            await _dataContext.SaveChangesAsync();
        }

    }

}