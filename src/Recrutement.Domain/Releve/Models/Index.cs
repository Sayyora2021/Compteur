namespace Recrutement.Domain.Releve.Models;

public class Index
{
    public Guid CompteurId { get; set; }         

    public decimal Value { get; set; }

    public DateTime Date { get; set; } 

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