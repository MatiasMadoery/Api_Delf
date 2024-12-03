using System;
using System.Collections.Generic;

namespace Api_Delf.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public string? Numero { get; set; }

    public DateTime Fecha { get; set; }

    public int ClienteId { get; set; }
    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<ArticuloCantidade>? ArticuloCantidades { get; set; } = new List<ArticuloCantidade>();

    
}
