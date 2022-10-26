using System;
using System.Collections.Generic;

namespace AgavalPruebaPart1.Models.DB
{
    public partial class Empleado
    {
        public int Idempleado { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
