using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Recrutement.Domain.Abstractions;
using Recrutement.Domain.Patrimoine;
using Recrutement.Domain.Patrimoine.Queries;
using Recrutement.Domain.Releve;
using Recrutement.Domain.Utilisateur;
using Recrutement.Infrastructure.Options;
using Recrutement.Infrastructure.Repositories;

namespace Recrutement.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediatRConfig(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg  => cfg.RegisterServicesFromAssemblyContaining<GetAllCompteursQuery>());
        return serviceCollection;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddDbContext<DataContext>((provider, options) =>
                {
                    var databaseOptions = provider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
                    options.UseSqlServer(databaseOptions.ConnectionString, sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                        sqlOptions.CommandTimeout(Convert.ToInt32(databaseOptions.CommandTimeout));
                    });
                },
                ServiceLifetime.Scoped
            );
        
        return serviceCollection;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IPatrimoineRepository, PatrimoineRepository>();
        serviceCollection.AddTransient<IReleveRepository, ReleveRepository>();
        serviceCollection.AddTransient<IUtilisateurRepository, UtilisateurRepository>();

        
        return serviceCollection;
    }

    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IReleveService, ReleveService>();
        
        return serviceCollection;
    }
}