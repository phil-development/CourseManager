using CourseManager.Infrastructure.Context;
using CourseManager.Application.Services.Interfaces;
using CourseManager.Application.Services.Implementations;
using CourseManager.Domain.Interfaces;
using CourseManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ? Conex�o com o banco SQL Server
builder.Services.AddDbContext<CourseManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? Inje��o de Depend�ncias - Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserDetailService, UserDetailService>();
builder.Services.AddScoped<IUserCourseService, UserCourseService>();

// ? Inje��o de Depend�ncias - Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUserDetailRepository, UserDetailRepository>();
builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();

// ? Configura��o do Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CourseManager API",
        Version = "v1",
        Description = "API para gerenciamento de cursos e usu�rios"
    });
});

var app = builder.Build();

// ? Swagger apenas em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CourseManager API v1");
        c.RoutePrefix = "swagger"; // URL: http://localhost:8080/swagger
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ? MIGRATIONS AUTOM�TICAS AO INICIAR
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CourseManagerContext>();
    db.Database.Migrate();
}

app.Run();
