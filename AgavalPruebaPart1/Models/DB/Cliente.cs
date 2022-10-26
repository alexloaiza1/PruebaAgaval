using System;
using System.Collections.Generic;

namespace AgavalPruebaPart1.Models.DB
{
    public partial class Cliente
    {
        public Cliente()
        {
            Productos = new HashSet<Producto>();
            Secciones = new HashSet<Seccione>();
        }

        public int Idcliente { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public int Idtipo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }

        public virtual Tipospersona IdtipoNavigation { get; set; } = null!;
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Seccione> Secciones { get; set; }
    }
}
