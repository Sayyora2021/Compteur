using MediatR;
using Recrutement.Domain.Abstractions;
using Recrutement.Domain.Releve.Queries;
using Index = Recrutement.Domain.Releve.Models.Index;

namespace Recrutement.Domain.Releve;

public class ReleveQueryHandlers :
    IRequestHandler<GetAllIndexesQuery, IList<Index>>,
    IRequestHandler<GetIndexesByCompteurQuery, IList<Index>>
{
    private readonly IReleveService _releveService;

    public ReleveQueryHandlers(IReleveService releveService)
    {
        _releveService = releveService;
    }
    
    public async Task<IList<Index>> Handle(GetAllIndexesQuery request, CancellationToken cancellationToken)
    {
        return await _releveService.GetAllIndexAsync();
    }

    public async Task<IList<Index>> Handle(GetIndexesByCompteurQuery request, CancellationToken cancellationToken)
    {
        return await _releveService.GetIndexCompteurAsync(request.CompteurId);
    }
}