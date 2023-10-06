using Index = Recrutement.Domain.Releve.Models.Index;

namespace Recrutement.Api.Response;

public class IndexResponse
{
    public Guid CompteurId { get; set; }
    public DateTime DateMesure { get; set; }
    public decimal Valeur { get; set; }

    public static IndexResponse From(Index index)
        => new()
        {
            CompteurId = index.CompteurId,
            DateMesure = index.Date,
            Valeur = index.Value
        };
}