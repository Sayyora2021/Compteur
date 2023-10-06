using Microsoft.EntityFrameworkCore;
using Recrutement.Domain.Utilisateur;
using Recrutement.Infrastructure.Repositories.Entities;
using Utilisateur = Recrutement.Domain.Utilisateur.Models.Utilisateur;
using UtilisateurAdd = Recrutement.Domain.Utilisateur.Models.UtilisateurAdd;

namespace Recrutement.Infrastructure.Repositories;

public class UtilisateurRepository: IUtilisateurRepository
{
    private readonly DataContext _dataContext;

    public UtilisateurRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IEnumerable<Utilisateur> GetAll()
    {
        return _dataContext.Utilisateurs
            .Select(u => new Utilisateur(u.Id, u.Nom, u.Prenom)) 
            .ToList();
    }


    public async Task CreateUtilisateurAsync(UtilisateurAdd utilisateurAdd)
    {

        var utilisateurData = new UtilisateurDb
        {
            Nom = utilisateurAdd.Nom,
            Prenom = utilisateurAdd.Prenom

        };
        await _dataContext.AddAsync(utilisateurData);
        await _dataContext.SaveChangesAsync();
    }
}