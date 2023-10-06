namespace Recrutement.Domain.Releve.Models;

public class Index
{
    public Guid CompteurId { get; }         

    public decimal Value { get; }

    public DateTime Date {get; } 

    public Index(
        Guid compteurId,
        decimal value,
        DateTime date
    )
    {
        CompteurId = compteurId;
        Value = value;
        Date = date;
    }
}