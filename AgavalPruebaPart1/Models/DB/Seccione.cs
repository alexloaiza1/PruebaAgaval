using System;
using System.Collections.Generic;

namespace AgavalPruebaPart1.Models.DB
{
    public partial class Seccione
    {
        public int Idseccion { get; set; }
        public int Idcliente { get; set; }
        public string? Descripcion { get; set; }

        public virtual Cliente oCliente { get; set; } = null!;
    }
}
