using eCommerce.Infraestructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//Add infraestructure services
builder.Services.AddInfrastructure();
//Add core services
builder.Services.AddCore();
//Add authorization services
builder.Services.AddAuthorization();
//Add controller
builder.Services.AddControllers().AddJsonOptions(options =>
{ options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
//Add automappers
builder.Services.AddAutoMapper(
    typeof(ApplicationUserMappingProfile).Assembly,
    typeof(RegisterRequestMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();
//Fluent validations


app.MapGet("/", () => "Hello World!");

app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();
//Authorization
app.UseAuthorization();
//Authentication
app.UseAuthentication();
//Endpoints
app.MapControllers();
app.Run();
