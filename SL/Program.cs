var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurar CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin(); // Permitir cualquier origen
    options.AllowAnyMethod(); // Permitir cualquier método
    options.AllowAnyHeader(); // Permitir cualquier encabezado
});

app.UseAuthorization();

app.MapControllers();

app.Run();
