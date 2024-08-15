using CustomSoftMaqueta.Infrastructure.profiles;
using MediatR;
using CustomSoftMaqueta.Infrastructure.data;
using CustomSoftMaqueta.Domain.Interfaces;
using Npgsql;
using System.Data;
using CustomSoftMaqueta.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});
builder.Services.AddAutoMapper(typeof(UserProfile));
string storagePath = "C:\\Users\\jozzm\\Downloads\\"; 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
var app = builder.Build();
app.UseMiddleware<ExceptionRFC7807Middleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/errors");
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
