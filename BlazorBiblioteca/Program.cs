using BlazorBiblioteca.Components;
using BlazorBiblioteca.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

//Add Servicios: Controller y HTTPClient
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

//Add servicio LibroDBContext
builder.Services.AddDbContext<LibroDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

//Agregar el mapeo del controlador
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorBiblioteca.Client._Imports).Assembly);

app.Run();
