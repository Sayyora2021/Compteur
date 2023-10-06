using Recrutement.Domain.Patrimoine.Models;

namespace Recrutement.Api.Response;

public class CompteurResponse
{
    public Guid Id { get; set; }
    public string NumeroSerie { get; set; } = null!;
    public DateTime DatePose { get; set; }

    public static CompteurResponse From(Compteur compteur) =>
        new()
        {
            Id = compteur.Id,
            NumeroSerie = compteur.NumeroSerie,
            DatePose = compteur.DateDePose.GetValueOrDefault()
        };
}