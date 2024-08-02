using ControllersExamples.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // adds all controllers

var app = builder.Build();
//enable static files
app.UseStaticFiles();
//enable the routing
app.UseRouting();

app.MapControllers();

app.Run();

