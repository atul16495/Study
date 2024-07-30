var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enable routing
app.UseRouting();

//creating endpoints
app.UseEndpoints(async endpoints =>
{
endpoints.Map("files/{filename=sample}.{extention}", async context =>
{
    string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"In files- {filename} - {extension}");
});
endpoints.Map("employee/profile/{employeename}", async context =>
{
    string? employeename = Convert.ToString(context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync($"Hello- {employeename}");
});

endpoints.Map("product/details/{id:int?}", async context => {
    if (context.Request.RouteValues.ContainsKey("id"))
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product details - {id}");
    }
    else
    {
        await context.Response.WriteAsync($"Product details - id is no supplied");
    }
    
   });
    // daily digest report/{reportdate}
    endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"In daily-digrest-report-{reportDate.ToShortDateString()}");
    });

    //cities/cityid
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync(@"city information {cityId}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
