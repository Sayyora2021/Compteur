using MediatR;
using Index = Recrutement.Domain.Releve.Models.Index;

namespace Recrutement.Domain.Releve.Queries;

public class GetAllIndexesQuery : IRequest<IList<Index>>
{
}