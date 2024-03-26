using Microsoft.AspNetCore.Identity;

namespace HydraulicFix.Data;

public class ApplicationUser : IdentityUser
{
    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Cedula { get; set; }

    public string? NickName { get; set; }
}
