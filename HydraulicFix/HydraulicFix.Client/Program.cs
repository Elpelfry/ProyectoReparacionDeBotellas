using HydraulicFix.Client;
using Shared.Dto;
using HydraulicFix.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;
using Radzen;
using Shared.Interfaces;
using Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

//Servicios 
builder.Services.AddScoped<IHydraulicAsp<ApplicationUserDto>, UsersService>();
builder.Services.AddScoped<IHydraulicAsp<IdentityRole>, RolesService>();
builder.Services.AddScoped<IHydraulicAsp<IdentityUserRole<string>>, UserRolesService>();
builder.Services.AddScoped<IHydraulic<Abonos>, AbonosService>();
builder.Services.AddScoped<IHydraulic<CategoriaProductos>, CategoriaProductosService>();
builder.Services.AddScoped<IHydraulic<Configuraciones>, ConfiguracionesService>();
builder.Services.AddScoped<IHydraulic<Productos>, ProductosService>();
builder.Services.AddScoped<IHydraulic<Proveedores>, ProveedoresService>();
builder.Services.AddScoped<IHydraulic<Reparaciones>, ReparacionesService>();
builder.Services.AddScoped<IHydraulic<Ventas>, VentasService>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

await builder.Build().RunAsync();
