using Microsoft.EntityFrameworkCore;
using Recrutement.Domain.Patrimoine;
using Recrutement.Domain.Patrimoine.Models;

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

    //public async Task<IList<Compteur>> GetCompteurByIdAsync(Guid id)
    //{
    //    var appareil = await _dataContext.Appareils.Include(r=>r.Id).FirstOrDefaultAsync(r=>r.Id == id);

    //    if(appareil != null)
    //    {
    //        var compteurs = appareil.Id.FirstOrDefaultAsync(c=> c.Id);
               
    //        return compteurs;
    //    }
    //    else
    //    {
    //        return new List<Compteur>();
    //    }
    //}

    public async Task<bool> CompteurExistsAsync(Guid compteurId)
    {
        var compteur = await _dataContext.Appareils.FindAsync(compteurId);
        return compteur != null;
    }
}