using HydraulicFix.Services;
using HydraulicFix.Components;
using HydraulicFix.Components.Account;
using HydraulicFix.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using Shared.Dto;
using HydraulicFix.Client.Services;
using Radzen;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Configuration.AddEnvironmentVariables();

//Servicios
builder.Services.AddScoped<IServerAsp<ApplicationUser>, UsersService>();
builder.Services.AddScoped<IServerAsp<IdentityRole>, RolesService>();
builder.Services.AddScoped<IServerAsp<IdentityUserRole<string>>, UserRolesService>();
builder.Services.AddScoped<IServer<Abonos>, AbonosService>();
builder.Services.AddScoped<IServer<CategoriaProductos>, CategoriaProductosService>();
builder.Services.AddScoped<IServer<Configuraciones>, ConfiguracionesService>();
builder.Services.AddScoped<IServer<Productos>, ProductosService>();
builder.Services.AddScoped<IServer<Proveedores>, ProveedoresService>();
builder.Services.AddScoped<IServer<Reparaciones>, ReparacionesService>();
builder.Services.AddScoped<IServer<Ventas>, VentasService>();
builder.Services.AddScoped<IServer<MetodoPagos>, MetodosPagosService>();
builder.Services.AddScoped<IServer<Estados>, EstadosService>();
builder.Services.AddScoped<IServer<Condiciones>, CondicionesService>();
builder.Services.AddScoped<IServer<Gastos>, GastosService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<IdentityUserService>();
builder.Services.AddScoped<ConfiguracionesService>();
builder.Services.AddScoped<ProductosService>();
builder.Services.AddScoped<AbonosService>();
builder.Services.AddScoped<MetodoPagos>();
builder.Services.AddScoped<UsersService>();

builder.Services.AddScoped<IClient<Abonos>, AbonosServiceClient>();
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30))));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped(a => 
    new HttpClient {BaseAddress = new Uri((builder.Configuration.GetSection("RutaApi")!.Value)!) 
    });

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(HydraulicFix.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
