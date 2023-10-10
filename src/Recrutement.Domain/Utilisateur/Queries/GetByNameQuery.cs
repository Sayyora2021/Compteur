using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recrutement.Domain.Utilisateur.Queries
{
    public class GetByNameQuery : IRequest<List<IUtilisateurRepository>>
    {
        public string Nom { get; set; }

        public GetByNameQuery(string nom)
        {
            Nom = nom;
        }
    
    }
}
