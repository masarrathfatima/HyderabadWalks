using HyderabadWalks.API.Data;
using HyderabadWalks.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HydWalksDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HydWalksConnectionString")));

builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

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


//app.UseHttpsRedirection();: Ensures that all HTTP requests are redirected to HTTPS, enforcing secure connections.

//app.UseAuthorization();: Adds authorization middleware, ensuring that requests are authorized based on the application's authorization policies.

//app.MapControllers();: Maps incoming HTTP requests to the appropriate controller actions, enabling the routing mechanism for API endpoints or MVC controllers.

//app.Run();: Starts the application and processes incoming requests.
