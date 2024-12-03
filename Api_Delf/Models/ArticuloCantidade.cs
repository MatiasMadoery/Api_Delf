using System;
using System.Collections.Generic;

namespace Api_Delf.Models;

public partial class ArticuloCantidade
{
    public int ArticuloId { get; set; }

    public int PedidoId { get; set; }

    public int Id { get; set; }

    public int Cantidad { get; set; }

    public virtual Articulo? Articulo { get; set; }

    public virtual Pedido? Pedido { get; set; }
}
