using System;
using System.Collections.Generic;

namespace AgavalPruebaPart1.Models.DB
{
    public partial class Tipospersona
    {
        public Tipospersona()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Idtipo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
