using Recrutement.Infrastructure.Extensions;
using Recrutement.Infrastructure.Options;

namespace Recrutement.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddOptions<DatabaseOptions>()
            .Configure<IConfiguration>((options, config) => config.GetSection("Database").Bind(options));

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddMediatRConfig()
            .AddDbContext()
            .AddRepositories()
            .AddServices()
            .AddOpenApiDocument(options => {
                options.PostProcess = doc => {
                    doc.Info.Title = "Recrutement API";
                };
            });

        return builder;
    }
}