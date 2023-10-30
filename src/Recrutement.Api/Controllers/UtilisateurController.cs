using Microsoft.AspNetCore.Mvc;
using MediatR;
using Recrutement.Domain.Utilisateur;
using Recrutement.Domain.Utilisateur.Models;
using System.Net;
using Recrutement.Infrastructure.Repositories;
using Recrutement.Domain.Utilisateur.Queries;
using Recrutement.Domain.Utilisateur.Commands;
using Recrutement.Api.Response;

namespace Recrutement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UtilisateurController : ControllerBase
{
    private readonly IMediator _mediator;

    public UtilisateurController(IMediator mediator)
    {
        _mediator = mediator;
    }
    //ancienne version
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("all")]
    public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAllQuery()
    {
        var utilisateurs =await _mediator.Send(new GetAllQuery());
        return Ok(utilisateurs);
    }
   
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("create")]
    public async Task<ActionResult> CreateUtilisateurAsync([FromBody] ApiUtilisateur apiUtilisateur)
    {
        try
        {
            // Create a UtilisateurAdd object from apiUtilisateur
            var utilisateurAdded = new CreateUtilisateurCommand(apiUtilisateur.Nom, apiUtilisateur.Prenom);

            // Create a new Utilisateur using the mediator
            await _mediator.Send(utilisateurAdded);

            // Return HTTP OK response with the created utilisateur
            return Ok(utilisateurAdded);
        }
        catch (Exception ex)
        {
            // En cas d'échec
            return BadRequest("Échec de la création de l'utilisateur : " + ex.Message);
        }

    }
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("search/{nom}")]
    public async Task<ActionResult<Utilisateur>> GetByName([FromRoute] string nom)
    {
        var utilisateurResult = await _mediator.Send(new GetByNameQuery (nom));
        return utilisateurResult;

    }
}

