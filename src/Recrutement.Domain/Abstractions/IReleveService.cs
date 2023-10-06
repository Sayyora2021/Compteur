namespace Recrutement.Domain.Abstractions;
using Index = Recrutement.Domain.Releve.Models.Index;

public interface IReleveService
{
    /// <summary>
    /// Récupération de tous les index
    /// </summary>
    /// <returns>List of <see cref="Index"/></returns>
    Task<IList<Index>> GetAllIndexAsync();
    
    /// <summary>
    /// Récupération de tous les index d'un compteur
    /// </summary>
    /// <param name="compteurId"></param>
    /// <returns>List of <see cref="Index"/></returns>
    Task<IList<Index>> GetIndexCompteurAsync(Guid compteurId);
}