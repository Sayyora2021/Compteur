using MediatR;

namespace Recrutement.Domain.Utilisateur.Queries
{
    public class GetAllQuery: IRequest<IEnumerable<Models.Utilisateur>>
    {
    }
}
