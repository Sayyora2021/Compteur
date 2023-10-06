using FluentAssertions;
using Recrutement.Infrastructure.Extensions;
using Recrutement.Infrastructure.Repositories.Entities;

namespace Recrutement.Tests.Extensions;

public class UtilisateurExtensionsTests
{
    [Fact]
    public void ShouldGetFullNameUtilisateur()
    {
        var utilisateur = new Utilisateur
        {
            Nom = "TOTO",
            Prenom = "titi"
        };

        utilisateur.GetFullName().Should().NotBeNullOrEmpty();
    }
}