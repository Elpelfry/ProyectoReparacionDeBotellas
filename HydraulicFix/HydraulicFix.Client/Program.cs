using HydraulicFix.Client;
using Shared.Dto;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;
using Radzen;
using Shared.Interfaces;
using Shared.Models;
using HydraulicFix.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

//Servicios
builder.Services.AddScoped<IClientAsp<ApplicationUserDto>, UsersServiceClient>();
builder.Services.AddScoped<IClientAsp<IdentityRole>, RolesServiceClient>();
builder.Services.AddScoped<IClientAsp<IdentityUserRole<string>>, UserRolesServiceClient>();
builder.Services.AddScoped<IClient<Abonos>, AbonosServiceClient>();
builder.Services.AddScoped<IClient<CategoriaProductos>, CategoriaProductosServiceClient>();
builder.Services.AddScoped<IClient<Configuraciones>, ConfiguracionesServiceClient>();
builder.Services.AddScoped<IClient<Productos>, ProductosServiceClient>();
builder.Services.AddScoped<IClient<Proveedores>, ProveedoresServiceClient>();
builder.Services.AddScoped<IClient<Reparaciones>, ReparacionesServiceClient>();
builder.Services.AddScoped<IClient<Ventas>, VentasServiceClient>();
builder.Services.AddScoped<IClient<Abonos>, AbonosServiceClient>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

await builder.Build().RunAsync();
