using Minesweeper.API.Managers;
using Minesweeper.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<IGameCreatingService, GameCreatingService>();
builder.Services.AddTransient<IGameProcessingService, GameProcessingService>();
builder.Services.AddTransient<IGameDrawingService, GameDrawingService>();
builder.Services.AddTransient<IGameValidationManager, GameValidationManager>();
builder.Services.AddTransient<IGameManager, GameManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options => options
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true)
    .AllowCredentials());
app.UseAuthorization();
app.MapControllers();
app.Run();
