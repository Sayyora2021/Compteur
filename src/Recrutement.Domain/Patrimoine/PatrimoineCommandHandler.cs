using MediatR;
using Recrutement.Domain.Patrimoine.Commands;
using Recrutement.Domain.Releve;
namespace Recrutement.Domain.Patrimoine
{
    public class PatrimoineCommandHandler 
        :IRequestHandler<CreateCompteurCommand> ,
        IRequestHandler<DeleteCompteurCommand>
    {
        private readonly IPatrimoineRepository _patrimoineRepository;
        private readonly IReleveRepository _releveRepository;
        public PatrimoineCommandHandler(IPatrimoineRepository patrimoineRepository, IReleveRepository releveRepository)
        {
            _patrimoineRepository = patrimoineRepository;
            _releveRepository = releveRepository;
        }

        public async Task Handle(CreateCompteurCommand request, CancellationToken cancellationToken)
        {
            await _patrimoineRepository.CreateCompteurAsync(request.NumeroSerie);
        }
        public async Task Handle(DeleteCompteurCommand request, CancellationToken cancellationToken)
        {
            await _releveRepository.DeleteIndexAsync(request.compteurId);
            await _patrimoineRepository.DeleteCompteurAsync(request.compteurId);
        }


    }
}
