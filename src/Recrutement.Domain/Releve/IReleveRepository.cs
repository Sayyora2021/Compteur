namespace Recrutement.Domain.Releve;
using Index = Recrutement.Domain.Releve.Models.Index;

public interface IReleveRepository
{
    /// <summary>
    /// Récupération de tous les index
    /// </summary>
    /// <returns></returns>
    Task<IList<Index>> GetAllIndexesAsync();

    /// <summary>
    /// Récupération de tous les index d'un compteur
    /// </summary>
    /// <param name="compteurId"></param>
    /// <returns></returns>
    Task<IList<Index>> GetIndexesByCompteurAsync(Guid compteurId);

    /// <summary>
    /// Création d'un index
    /// </summary>
    /// <param name="index"><see cref="Index"/></param>
    /// <returns></returns>
    Task AddIndexAsync(Index index);
}