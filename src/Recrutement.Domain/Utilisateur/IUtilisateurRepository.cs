using Recrutement.Domain.Utilisateur.Models;

namespace Recrutement.Domain.Utilisateur
{
    public interface IUtilisateurRepository
    {

        IEnumerable<Models.Utilisateur>GetAll();
        Task <Models.Utilisateur> GetByNameAsync(string name);


        Task CreateUtilisateurAsync(UtilisateurAdd utilisateurAdd);

       

    }
}
