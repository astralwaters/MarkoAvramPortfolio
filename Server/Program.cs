using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDBContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration[key:"Jwt:Issuer"],
            ValidAudience = builder.Configuration[key:"Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[key:"Jwt:Key"]))
        };
    });

builder.Services.AddAutoMapper(typeof(DTOMappings));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    ));

builder.Services.AddRouting(options => options.LowercaseUrls=true);

builder.Services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "MarkoAvramServer API");
    swaggerUIOptions.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
