using Microsoft.EntityFrameworkCore;
using Recrutement.Domain.Releve;
using Recrutement.Infrastructure.Repositories.Entities;
using Index = Recrutement.Domain.Releve.Models.Index;

namespace Recrutement.Infrastructure.Repositories;

public class ReleveRepository : IReleveRepository
{
    private readonly DataContext _context;

    public ReleveRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IList<Index>> GetAllIndexesAsync()
    {
        var releves = await _context.Releves.ToListAsync();

        return releves
            .Where(r => r.Type == "Index")
            .Select(r => new Index(r.AppareilId, r.Valeur, r.DateMesure))
            .ToList();
    }

    public async Task<IList<Index>> GetIndexesByCompteurAsync(Guid compteurId)
    {
        var releves = await _context
            .Releves
            .Where(r => r.AppareilId == compteurId)
            .ToListAsync();

        return releves
            .Select(r => new Index(r.AppareilId, r.Valeur, r.DateMesure))
            .ToList();
    }

    public async Task AddIndexAsync(Index index)
    {
        await _context.Releves.AddAsync(new Releve
        {
            AppareilId = index.CompteurId,
            DateMesure = index.Date,
            Type = "Index",
            Valeur = index.Value
        });
        await _context.SaveChangesAsync();
    }
}