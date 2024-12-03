using System;
using System.Collections.Generic;

namespace Api_Delf.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contrasena { get; set; }

    public string? Rol { get; set; }
}
