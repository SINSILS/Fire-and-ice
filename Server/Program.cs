using Server.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.MapGet("/", () => "This is game server's api");
app.MapHub<GameHub>("/gameHub");
app.Run("http://localhost:7021");
