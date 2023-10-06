using MediatR;
using Index = Recrutement.Domain.Releve.Models.Index;

namespace Recrutement.Domain.Releve.Queries;

public class GetIndexesByCompteurQuery : IRequest<IList<Index>>
{
    public Guid CompteurId { get; }

    public GetIndexesByCompteurQuery(Guid compteurId)
    {
        CompteurId = compteurId;
    }
}