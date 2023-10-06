using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recrutement.Domain.Utilisateur;
using Recrutement.Domain.Utilisateur.Models;
using System.Net;

namespace Recrutement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UtilisateurController : ControllerBase
{
    private readonly IUtilisateurRepository _utilisateurRepository;

    public UtilisateurController(IUtilisateurRepository utilisateurRepository)
    {
        _utilisateurRepository = utilisateurRepository;
    }
    //ancienne version
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("all")]
    public async Task<ActionResult<IEnumerable<Utilisateur>>> GetListeUtilisateur()
    {
        var utilisateurs =  _utilisateurRepository.GetAll().ToList();
        return Ok(utilisateurs);
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("search/{nom}")]
    public async Task<ActionResult<List<Utilisateur>>> GetByNom([FromRoute] string nom)
    {
        var utilisateursResult = new List<Utilisateur>();
        foreach (var utilisateur in _utilisateurRepository.GetAll())
        {
            if (utilisateur.Nom.Contains(nom))
            {
                utilisateursResult.Add(utilisateur);
            }
        }

        return utilisateursResult;
    }





    //updated version
    //[HttpGet]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[Route("search/{nom}")]
    //public async Task<ActionResult<List<Utilisateur>>> GetByNom([FromRoute] string nom)
    //{
    //    var utilisateursResult = new List<Utilisateur>();
    //    foreach (var utilisateur in _utilisateurRepository.GetAll())
    //    {
    //        if (utilisateur.Nom.Contains(nom))
    //        {
    //            utilisateursResult.Add(utilisateur);
    //        }
    //    }

    //    return utilisateursResult;
    //}

    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("create")]
    public async Task<ActionResult> CreateUtilisateurAsync([FromBody] ApiUtilisateur apiUtilisateur)
    {
        try
        {
            // Create a UtilisateurAdd object from apiUtilisateur
            var utilisateurAdded = new UtilisateurAdd(apiUtilisateur.Nom, apiUtilisateur.Prenom);

            // Create a new Utilisateur using the repository
            await  _utilisateurRepository.CreateUtilisateurAsync(utilisateurAdded);

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

