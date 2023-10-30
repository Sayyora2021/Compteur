using MediatR;
using Recrutement.Domain.Utilisateur.Queries;
using Utilisateur = Recrutement.Domain.Utilisateur.Models.Utilisateur;

namespace Recrutement.Domain.Utilisateur;
public class UtilisateurQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Models.Utilisateur>>,
   IRequestHandler<GetByNameQuery, Models.Utilisateur>
{
    private readonly IUtilisateurRepository _utilisateurRepository;

    public UtilisateurQueryHandler(IUtilisateurRepository utilisateurRepository)
    {
        _utilisateurRepository = utilisateurRepository;
    }

    public Task<IEnumerable<Models.Utilisateur>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var utilisateurs = _utilisateurRepository.GetAll().ToList();
        return Task.FromResult<IEnumerable<Models.Utilisateur>>(utilisateurs);
    }
    public async Task<Models.Utilisateur> Handle(GetByNameQuery request, CancellationToken cancellationToken)
    {
        Models.Utilisateur utilisateur = await _utilisateurRepository.GetByNameAsync(request.Name);
        return utilisateur;
    }

}
