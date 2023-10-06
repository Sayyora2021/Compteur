using Recrutement.Infrastructure.Repositories.Core;
using System.ComponentModel.DataAnnotations;

namespace Recrutement.Infrastructure.Repositories.Entities;

public class UtilisateurDb : IEntity
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nom { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Prenom { get; set; }

    
}