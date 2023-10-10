using Microsoft.AspNetCore.Mvc;
using MediatR;
using Recrutement.Domain.Utilisateur;
using Recrutement.Domain.Utilisateur.Models;
using System.Net;
using Recrutement.Infrastructure.Repositories;
using Recrutement.Domain.Utilisateur.Queries;
using Recrutement.Domain.Utilisateur.Commands;

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
    //public async Task<ActionResult<IEnumerable<Utilisateur>>> GetListeUtilisateur()
    //{
    //    var utilisateurs =  _utilisateurRepository.GetAll().ToList();
    //    return Ok(utilisateurs);
    //}
    public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAllQuery()
    {
        var utilisateurs =await _mediator.Send(new GetAllQuery());
        return Ok(utilisateurs);
    }
    //[HttpGet]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[Route("search/{nom}")]
    //public async Task<ActionResult<List<Utilisateur>>> GetByNom([FromRoute] string nom)
    //{
        //var utilisateursResult = new List<Utilisateur>();
        //foreach (var utilisateur in _utilisateurRepository.GetAll())
        //{
        //    if (utilisateur.Nom.Contains(nom))
        //    {
        //        utilisateursResult.Add(utilisateur);
        //    }
        //}

        //return utilisateursResult;
        
   // }



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
}

