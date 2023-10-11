using Recrutement.Domain.Patrimoine.Models;
using Index = Recrutement.Domain.Releve.Models.Index;

namespace Recrutement.Domain.Patrimoine;

public interface IPatrimoineRepository
{
    /// <summary>
    /// Récupération de tous les index
    /// </summary>
    /// <returns>List of <see cref="Index"/></returns>
    Task<IList<Compteur>> GetAllCompteursAsync();


    //Task<IList<Compteur>> GetCompteurByIdAsync(Guid id);

    /// <summary>
    /// Vérification de l'existance d'un compteur
    /// </summary>
    /// <param name="compteurId"></param>
    /// <returns></returns>
    Task<bool> CompteurExistsAsync(Guid compteurId);
    Task CreateCompteurAsync(string numeroSerie);
    Task DeleteCompteurAsync(Guid compteurId);
}