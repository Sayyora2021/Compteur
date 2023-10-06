using Microsoft.EntityFrameworkCore;
using Recrutement.Api.Controllers;
using Recrutement.Api.Extensions;
using Recrutement.Infrastructure.Extensions;
using Recrutement.Infrastructure.Options;
using Recrutement.Infrastructure.Repositories;
using System;
using System.Diagnostics;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddOptions()
    .AddServices();

builder.Services
    .AddRouting()
    .AddControllers();

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi3(options => options.AdditionalSettings.Add("displayRequestDuration", true));

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider
        .GetRequiredService<DataContext>();
    
    await dataContext.Database.EnsureDeletedAsync();
    await dataContext.Database.MigrateAsync();
}

app.Run();