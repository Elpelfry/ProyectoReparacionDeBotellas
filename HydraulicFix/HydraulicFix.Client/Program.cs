using HydraulicFix.Client;
using HydraulicFix.Client.Dto;
using HydraulicFix.Client.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;
using Radzen;
using Shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped<IHydraulicAsp<IdentityUserRole<string>>, UserRolesService>();
builder.Services.AddScoped<IHydraulicAsp<IdentityRole>, RolesService>();
builder.Services.AddScoped<IHydraulicAsp<ApplicationUserDto>, UsersService>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

await builder.Build().RunAsync();
