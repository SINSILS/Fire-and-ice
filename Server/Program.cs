using Server.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.MapGet("/", () => "This is game server's api");
app.MapHub<GameHub>("/gameHub");
app.Run();


//Su platformomis pasiziuret del rezoliucijos