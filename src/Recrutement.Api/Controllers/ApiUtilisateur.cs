namespace Recrutement.Api.Controllers
{
    public class ApiUtilisateur
    {
           public string Nom { get; set; }
            public string Prenom { get; set; }

        public ApiUtilisateur(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }
    }
}
