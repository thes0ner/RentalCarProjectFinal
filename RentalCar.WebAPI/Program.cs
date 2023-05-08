using Autofac;
using Autofac.Extensions.DependencyInjection;
using RentalCar.Business.DependencyResolvers.Autofac;
using RentalCar.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalCar.Core.Utilities.Security.Encryption;
using RentalCar.Core.Extensions;
using RentalCar.Core.Utilities.IoC;
using RentalCar.Core.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


//Autofac's Configurations
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
//End.

//CORS DI
builder.Services.AddCors();

//JWT's Configurations
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
//End.

//Dependency Injection
builder.Services.AddDependencyResolvers(new ICoreModule[]
        {
            new CoreModule()
        });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Middleware
app.ConfigureCustomExceptionMiddleware();

//CORS Request!
app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
