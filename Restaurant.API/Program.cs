using Restaurant.API.Middlewares;
using Restaurant.Application.Extensions;
using Restaurant.Infrastructure.Extensions;
using Restaurant.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddScoped<ExcetionHandlingMiddleware>();

var app = builder.Build();

var scope = app.Services.CreateScope();
{
    var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
    await seeder.Seed();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExcetionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();