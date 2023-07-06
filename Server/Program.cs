using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    ));

builder.Services.AddRouting(options => options.LowercaseUrls=true);

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
