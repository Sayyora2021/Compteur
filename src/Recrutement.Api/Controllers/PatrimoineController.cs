using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recrutement.Api.Response;
using Recrutement.Domain.Patrimoine.Commands;
using Recrutement.Domain.Patrimoine.Queries;

namespace Recrutement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PatrimoineController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatrimoineController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [Route("all")]
    public async Task<ActionResult<List<CompteurResponse>>> GetAllCompteurs()
    {
        var compteurs = await _mediator.Send(new GetAllCompteursQuery());
        return compteurs.Select(CompteurResponse.From).ToList();
    }

    [HttpPost]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [Route("create")]
    public async Task<ActionResult<Guid>> CreateCompteur([FromBody] string numeroSerie)
    {
        var id = await _mediator.Send(new CreateCompteurCommand(numeroSerie));
        return id;
    }
}