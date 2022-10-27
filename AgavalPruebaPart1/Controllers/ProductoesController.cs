using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgavalPruebaPart1.Models.DB;
using AgavalPruebaPart1.Models.DB.ViewModels;

namespace AgavalPruebaPart1.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly ServiciosAgavalContext _context;

        public ProductoesController(ServiciosAgavalContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public IActionResult Index()
        {
            List<Producto> lista = _context.Productos.Include(t => t.oClientess).ToList();
            return View(lista);

        }

        public IActionResult Producto_Detalle(int idProducto)
        {
            ProductosVM oProductoVM = new ProductosVM()
            {
                oProducto = new Producto(),
                oListaClientes = _context.Clientes.Select(persona => new SelectListItem()
                {
                    Text = persona.Nombre,
                    Value = persona.Idcliente.ToString()

                }).ToList()
            };

            if (idProducto != 0)
            {

                oProductoVM.oProducto = _context.Productos.Find(idProducto);
            }


            return View(oProductoVM);
        }


        [HttpPost]
        public IActionResult Producto_Detalle(ProductosVM oProductoVM)
        {
            if (oProductoVM.oProducto.Idproducto == 0)
            {
                _context.Productos.Add(oProductoVM.oProducto);

            }
            else
            {
                _context.Productos.Update(oProductoVM.oProducto);
            }

            try
            {
                _context.SaveChanges();

            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Productoes");
            }
            
            return RedirectToAction("Index", "Productoes");
        }


        [HttpGet]
        public IActionResult Eliminar(int idProducto)
        {

            Producto oProducto = _context.Productos.Include(c => c.oClientess).Where(e => e.Idproducto == idProducto).FirstOrDefault();

            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Producto oProducto)
        {


            _context.Productos.Remove(oProducto);
            try
            {

                _context.SaveChanges();

            }
            catch (Exception)
            {

              //  return RedirectToAction("Index", "Clientes"); ;
            }


            return RedirectToAction("Index", "Clientes");
        }

    }
}
