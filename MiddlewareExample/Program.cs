using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<Mycustommiddleware>();
var app = builder.Build();

app.Use(async(HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Middelerware 1 testing\n");
    await next(context);

});

//app.UseMiddleware<Mycustommiddleware>();
//app.UseMycustomMiddleware();
app.UseHelloCustomMiddleware();

app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middelerware 3 testing \n");
    
});

app.Run();
