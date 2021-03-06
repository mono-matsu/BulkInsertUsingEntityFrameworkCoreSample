using BulkInsertUsingEntityFrameworkCoreSample.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<MySqlDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySql");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), optionsBuilder => optionsBuilder.MinBatchSize(2)).LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddDbContextPool<PostgreSqlDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSql");
    options.UseNpgsql(connectionString, optionsBuilder => optionsBuilder.MinBatchSize(2)).LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddDbContextPool<SqlServerDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServer");
    options.UseSqlServer(connectionString, optionsBuilder => optionsBuilder.MinBatchSize(2)).LogTo(Console.WriteLine, LogLevel.Information);
});

var app = builder.Build();

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
