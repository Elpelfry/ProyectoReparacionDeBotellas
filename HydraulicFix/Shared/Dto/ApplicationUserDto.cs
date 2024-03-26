using Microsoft.AspNetCore.Identity;
namespace Shared.Dto;

public class ApplicationUserDto: IdentityUser
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public int Cedula { get; set; }
}
