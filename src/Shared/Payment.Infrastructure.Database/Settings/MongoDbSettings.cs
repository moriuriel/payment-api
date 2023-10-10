namespace Payment.Infrastructure.Database.Settings;

public sealed class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public string Collection { get; set; } = string.Empty;
}


