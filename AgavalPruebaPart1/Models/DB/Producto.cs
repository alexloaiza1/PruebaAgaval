using System;
using System.Collections.Generic;

namespace AgavalPruebaPart1.Models.DB
{
    public partial class Producto
    {
        public int Idproducto { get; set; }
        public int Idcliente { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; } = null!;
    }
}
