using MediatR;

namespace Recrutement.Domain.Releve.Commands;

public record CreateIndexCommand(Guid CompteurId, int Valeur) : IRequest;