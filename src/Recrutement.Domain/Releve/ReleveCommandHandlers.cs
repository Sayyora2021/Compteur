using MediatR;
using Recrutement.Domain.Releve.Commands;
using Index = Recrutement.Domain.Releve.Models.Index;

namespace Recrutement.Domain.Releve;

public class ReleveCommandHandlers
    : IRequestHandler<CreateIndexCommand>
{
    private readonly IReleveRepository _releveRepository;

    public ReleveCommandHandlers(IReleveRepository releveRepository)
    {
        _releveRepository = releveRepository;
    }
    
    public async Task Handle(CreateIndexCommand request, CancellationToken cancellationToken)
    {
        await _releveRepository.AddIndexAsync(new Index(request.CompteurId, request.Valeur, DateTime.UtcNow));
    }
}