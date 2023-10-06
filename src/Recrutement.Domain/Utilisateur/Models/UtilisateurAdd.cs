using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recrutement.Domain.Utilisateur.Models
{
    public class UtilisateurAdd
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public UtilisateurAdd(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }
    }
}
