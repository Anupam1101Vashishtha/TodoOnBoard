using Microsoft.EntityFrameworkCore;
using Todoonboard_api.Models;
using Todoonboard_api.Services;
using Todoonboard_api.Helpers;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.


// {
//     var services = builder.Services;
//     services.AddCors();
//     services.AddControllers();

//     // configure strongly typed settings object
//     services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

//     // configure DI for application services
//     services.AddScoped<IUserService, UserService>();
// }


builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlServer(configuration.GetConnectionString("WebApiDatabase")));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});


builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IUserService,UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseCors(x => x

        .AllowAnyOrigin()

        .AllowAnyMethod()

        .AllowAnyHeader());



    // custom jwt auth middleware

    app.UseMiddleware<JwtMiddleware>();



    app.MapControllers();

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.Run();
