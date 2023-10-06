namespace Recrutement.Infrastructure.Options;

public class DatabaseOptions
{
    public string ConnectionString { get; set; } = null!;
    public string CommandTimeout { get; set; }
}