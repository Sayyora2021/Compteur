using System.ComponentModel.DataAnnotations;
using Recrutement.Infrastructure.Repositories.Core;

namespace Recrutement.Infrastructure.Repositories.Entities;

public class Appareil : IEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string NumeroSerie { get; set; }

    public DateTimeOffset DatePose { get; set; }
    
    public DateTimeOffset? DateDepose { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Type { get; set; }
    
    public virtual ICollection<Releve> Releves { get; set; }
}