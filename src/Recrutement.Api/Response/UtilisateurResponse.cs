using Utilisateur = Recrutement.Domain.Utilisateur.Models.Utilisateur;
namespace Recrutement.Api.Response
{
    public class UtilisateurResponse
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public static UtilisateurResponse From(Utilisateur utilisateur) => new()
        {
            Id = utilisateur.Id,
            Nom = utilisateur.Nom,
            Prenom = utilisateur.Prenom

        };
    }
}
