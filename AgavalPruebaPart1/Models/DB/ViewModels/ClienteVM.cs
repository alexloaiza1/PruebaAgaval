using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgavalPruebaPart1.Models.DB.ViewModels
{
    public class ClienteVM
    {

        public Cliente oCliente { get; set; }

        public List<SelectListItem> oListaTipo  { get; set; }

}
}
