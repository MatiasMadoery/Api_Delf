using System;
using System.Collections.Generic;

namespace Api_Delf.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Cuit { get; set; }

    public string? Direccion { get; set; }

    public string? Altura { get; set; }

    public string? Departamento { get; set; }

    public string? Piso { get; set; }

    public string? Localidad { get; set; }

    public string? Provincia { get; set; }

    public string? Pais { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public bool Estado { get; set; }

    public int ViajanteId { get; set; }

    public virtual ICollection<Pedido>? Pedidos { get; set; } 

    public virtual Viajante? Viajante { get; set; } 
}
