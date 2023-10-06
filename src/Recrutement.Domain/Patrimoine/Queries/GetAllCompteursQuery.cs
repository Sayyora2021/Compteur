using MediatR;
using Recrutement.Domain.Patrimoine.Models;

namespace Recrutement.Domain.Patrimoine.Queries;

public class GetAllCompteursQuery : IRequest<IList<Compteur>>
{
}