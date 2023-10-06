using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Recrutement.Domain.Utilisateur.Models
{
    public class Utilisateur
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Utilisateur(long id, string nom, string prenom )
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;

        }


    }
}
