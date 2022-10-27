using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgavalPruebaPart1.Models.DB.ViewModels
{
    public class ProductosVM
    {

        public Producto oProducto { get; set; }

        public List<SelectListItem> oListaClientes { get; set; }

    }
}
