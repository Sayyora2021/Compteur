using MediatR;

namespace Recrutement.Domain.Patrimoine.Commands;

public record CreateCompteurCommand(string NumeroSerie) : IRequest<Guid>;