using MediatR;
using Recrutement.Domain.Utilisateur.Models;

namespace Recrutement.Domain.Utilisateur.Commands
{
    public record CreateUtilisateurCommand(string Nom, string Prenom) :IRequest;
    
}
