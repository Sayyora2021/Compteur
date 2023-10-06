using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recrutement.Api.Response;
using Recrutement.Domain.Releve.Commands;
using Recrutement.Domain.Releve.Queries;

namespace Recrutement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ReleveController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReleveController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [Route("all")]
    public async Task<ActionResult<List<IndexResponse>>> GetAllIndexes()
    {
        var indexes = await _mediator.Send(new GetAllIndexesQuery());
        return indexes.Select(IndexResponse.From).ToList();
    }
    
    [HttpGet]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [Route("compteur/{compteurId}")]
    public async Task<ActionResult<List<IndexResponse>>> GetAllIndexes([FromRoute] Guid compteurId)
    {
        var indexes = await _mediator.Send(new GetIndexesByCompteurQuery(compteurId));
        return indexes.Select(IndexResponse.From).ToList();
    }

    [HttpGet]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [Route("create/{compteurId}/{valeur}")]
    public async Task CreateIndex([FromRoute] Guid compteurId, int valeur)
    {
        await _mediator.Send(new CreateIndexCommand(compteurId, valeur));
    }
}