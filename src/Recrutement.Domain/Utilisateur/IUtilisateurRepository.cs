using Recrutement.Domain.Utilisateur;
using Recrutement.Domain.Utilisateur.Models;

namespace Recrutement.Domain.Utilisateur
{
    public interface IUtilisateurRepository
    {

        IEnumerable<Models.Utilisateur>GetAll();
        //Task GetAll(IUtilisateurRepository);
        
       Task  CreateUtilisateurAsync(UtilisateurAdd utilisateurAdd);

       

    }
}
