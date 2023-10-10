using Payment.Application.Extensions;
using Payment.CrossCutting.AppSettings;
using Payment.Infrastructure.Database.Settings;
using Payment.Infrastructure.Database.Extensions;
using Payment.Infrastructure.ExternalServices.PaymentAuthorizer;

var builder = WebApplication.CreateBuilder(args);

var configuration = AppSettingsConfiguration.GetConfiguration();
builder.Services.AddSingleton(configuration);

builder.Services.Configure<MongoDbSettings>(
    options => configuration.GetSection(nameof(MongoDbSettings)).Bind(options));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomMediatr();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddPaymentAuthorizerService(configuration);
builder.Services.AddCustomFluentValidation();

var settingsMongoDb = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

ArgumentNullException.ThrowIfNull(settingsMongoDb);

builder.Services.AddCustomMongoDbContext(settingsMongoDb);

builder.Services.AddApiVersioning(p =>
{
    p.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    p.ReportApiVersions = true;
    p.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddVersionedApiExplorer(p =>
{
    p.GroupNameFormat = "'v'VVV";
    p.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

