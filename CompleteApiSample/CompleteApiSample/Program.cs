using CompleteApiSample.Common.Constants;
using CompleteApiSample.Domain.Provider;
using CompleteApiSample.Domain.Repositories;
using CompleteApiSample.Domain.Services;
using CompleteApiSample.Infrastructure;
using CompleteApiSample.Infrastructure.Loggers;
using CompleteApiSample.Infrastructure.Repositories;
using CompleteApiSample.Middlewares;
using CompleteApiSample.Service;
using CompleteApiSample.Telemetry;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;

var resource = ResourceBuilder.CreateDefault().AddService(TelemetryKey.ServiceName);
var builder = WebApplication.CreateBuilder(args);

// Configure telemetry
resource.ConfigureTelemetry(builder);

// Configure Database
var connectionString = builder.Configuration.GetValue<string>(ConfigurationKey.ConnectionString);
if (!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddDbContextPool<LibraryDbContext>(
                    (s, o) => o
                        .UseNpgsql(connectionString)
                        .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>())
                    );
    builder.Services.AddScoped<LibraryDbContext>();
}

// Configure security

// Add Loggers
builder.Services.AddScoped<IFunctionalLogger, FunctionalLogger>();

// Add repositories to the container.
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Add services to the container.
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

// Configure Web
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Update database
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
await dbContext.Database.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
