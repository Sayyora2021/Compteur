using MediatR;
using Recrutement.Domain.Patrimoine.Models;
using Recrutement.Domain.Patrimoine.Queries;

namespace Recrutement.Domain.Patrimoine;

public class PatrimoineQueryHandlers :
    IRequestHandler<GetAllCompteursQuery, IList<Compteur>>
{
    private readonly IPatrimoineRepository _patrimoineRepository;

    public PatrimoineQueryHandlers(IPatrimoineRepository patrimoineRepository)
    {
        _patrimoineRepository = patrimoineRepository;
    }
    
    public async Task<IList<Compteur>> Handle(GetAllCompteursQuery request, CancellationToken cancellationToken)
    {
        return await _patrimoineRepository.GetAllCompteursAsync();
    }

   
}