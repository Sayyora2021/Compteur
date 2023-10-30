using MediatR;
using Recrutement.Domain.Utilisateur.Commands;
using Recrutement.Domain.Utilisateur.Models;

namespace Recrutement.Domain.Utilisateur
{
    public class UtilisateurCommandHandler : IRequestHandler<CreateUtilisateurCommand>
    {

        private readonly IUtilisateurRepository _repository;

        public UtilisateurCommandHandler(IUtilisateurRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateUtilisateurCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateUtilisateurAsync(new UtilisateurAdd(request.Nom, request.Prenom));

        }
    }
}
