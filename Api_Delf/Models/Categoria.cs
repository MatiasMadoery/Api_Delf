using System;
using System.Collections.Generic;

namespace Api_Delf.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Articulo>? Articulos { get; set; }
}
