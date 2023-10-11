namespace Recrutement.Domain.Patrimoine.Models;

public class Compteur
{
    public Guid Id { get; set; }   

    public string NumeroSerie { get; }     
    
    public DateTime? DateDePose { get; }     

    public Compteur(
        Guid id,
        string numeroSerie,
        DateTime? dateDePose)
    {
        Id = id;
        NumeroSerie = numeroSerie;
        DateDePose = dateDePose;
    }

    public Compteur(string numeroSerie)
    {
        NumeroSerie = numeroSerie;
    }
}