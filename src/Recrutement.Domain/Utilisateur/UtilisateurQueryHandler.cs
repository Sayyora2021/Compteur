using MediatR;
using Recrutement.Domain.Utilisateur.Queries;
using Utilisateur = Recrutement.Domain.Utilisateur.Models.Utilisateur;

namespace Recrutement.Domain.Utilisateur;
public class UtilisateurQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Models.Utilisateur>>
{
    private readonly IUtilisateurRepository _utilisateurRepository;

    public UtilisateurQueryHandler(IUtilisateurRepository utilisateurRepository)
    {
        _utilisateurRepository = utilisateurRepository;
    }

//public async Task<IEnumerable<Utilisateur>> Handle(GetAllQuery request, CancellationToken cancellationToken)
//{
//    // Effectuez la logique pour récupérer la liste des utilisateurs depuis le référentiel.
//    var utilisateurs = _utilisateurRepository.GetAll(); // Assurez-vous que votre référentiel prend en charge l'opération asynchrone.
//    return utilisateurs.ToList();
//}

    Task<IEnumerable<Models.Utilisateur>> IRequestHandler<GetAllQuery, IEnumerable<Models.Utilisateur>>.Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var utilisateurs = _utilisateurRepository.GetAll().ToList();
        return Task.FromResult<IEnumerable<Models.Utilisateur>>(utilisateurs);
    }
}
