using System;
using System.Collections.Generic;

namespace Api_Delf.Models;

public partial class Articulo
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public string? NombreImagen { get; set; }

    public int CategoriaId { get; set; }

    public virtual ICollection<ArticuloCantidade>? ArticuloCantidades { get; set; } 

    public virtual Categoria? Categoria { get; set; } 
}
