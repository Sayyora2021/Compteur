using MediatR;

namespace Recrutement.Domain.Patrimoine.Commands
{
    public record DeleteCompteurCommand(Guid compteurId): IRequest;
   
}
