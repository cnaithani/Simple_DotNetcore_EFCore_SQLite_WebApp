using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleEFCoreAPITemplate.Data;
using SimpleEFCoreAPITemplate.Data.Interfaces;
using static SimpleEFCoreAPITemplate.Data.RepositoryBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

//Configure DI for repositories
builder.Services.AddScoped<IDatabaseFactory, DatabaseFactory>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// configure DI for Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Add SQLite Database which will be created in project directory if not already created
var connBuilder = new SqliteConnectionStringBuilder("Data Source=AppDb.db");
connBuilder.DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, connBuilder.DataSource);
builder.Services.AddSqlite<DBCtx>(connBuilder.ToString());

var app = builder.Build();

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DBCtx>();
    if (db.Database.EnsureCreated())
    {
        // If database is been created for first time, it will be initialized with seed data
        SeedData.Initialize(db);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
