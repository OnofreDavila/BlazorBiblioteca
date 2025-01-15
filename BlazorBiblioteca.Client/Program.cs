using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Servicio HTTP
builder.Services.AddScoped(sp =>
new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:7052")
});
//--------------------

await builder.Build().RunAsync();
