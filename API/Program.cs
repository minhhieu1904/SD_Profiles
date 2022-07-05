using API.Configurations;
using API.Helpers.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();

// Add Identity and Authentication
builder.Services.AddAuthenticationConfigufation(builder.Configuration);

// RepositoryAccessor and Service
builder.Services.AddDependencyInjectionConfiguration();

// Swagger Config
builder.Services.AddSwaggerGenConfiguration();

//Exception Handling Middleware Error
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
