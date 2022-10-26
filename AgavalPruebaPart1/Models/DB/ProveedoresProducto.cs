using System;
using System.Collections.Generic;

namespace AgavalPruebaPart1.Models.DB
{
    public partial class ProveedoresProducto
    {
        public int Idproveedor { get; set; }
        public int Idproducto { get; set; }
        public string? DescripcionContrato { get; set; }

        public virtual Producto IdproductoNavigation { get; set; } = null!;
        public virtual Proveedore IdproveedorNavigation { get; set; } = null!;
    }
}
