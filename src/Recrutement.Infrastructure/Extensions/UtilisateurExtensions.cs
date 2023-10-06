using Recrutement.Domain.Utilisateur.Models;
using Recrutement.Infrastructure.Repositories.Entities;

namespace Recrutement.Infrastructure.Extensions;

public static class UtilisateurExtensions
{
    public static string GetFullName(this Utilisateur utilisateur) => utilisateur.Prenom + " " + utilisateur.Nom;
}