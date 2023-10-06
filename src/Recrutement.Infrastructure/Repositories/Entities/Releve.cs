using System.ComponentModel.DataAnnotations;
using Recrutement.Infrastructure.Repositories.Core;

namespace Recrutement.Infrastructure.Repositories.Entities;

public class Releve : IEntity
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(50)]
    public Guid AppareilId { get; set; }

    public DateTime DateMesure { get; set; }
    
    public decimal Valeur { get; set; }

    [Required]
    [MaxLength(10)]
    public string Type { get; set; }
    
    public virtual Appareil Appareil { get; set; }
}