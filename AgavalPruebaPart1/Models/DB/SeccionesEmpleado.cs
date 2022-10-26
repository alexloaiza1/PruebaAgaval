using System;
using System.Collections.Generic;

namespace AgavalPruebaPart1.Models.DB
{
    public partial class SeccionesEmpleado
    {
        public int Idseccion { get; set; }
        public int Idempleado { get; set; }
        public string? Cargo { get; set; }

        public virtual Empleado IdempleadoNavigation { get; set; } = null!;
        public virtual Seccione IdseccionNavigation { get; set; } = null!;
    }
}
