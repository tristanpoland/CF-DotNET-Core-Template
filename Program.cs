// Program.cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Hello from .NET Core on Cloud Foundry!");
app.MapGet("/env", () => {
    var port = Environment.GetEnvironmentVariable("PORT") ?? "Not set";
    var cfInstance = Environment.GetEnvironmentVariable("CF_INSTANCE_INDEX") ?? "Not set";
    var memory = Environment.GetEnvironmentVariable("MEMORY_LIMIT") ?? "Not set";
    
    return $"PORT: {port}\nCF_INSTANCE_INDEX: {cfInstance}\nMEMORY_LIMIT: {memory}";
});

app.Run();