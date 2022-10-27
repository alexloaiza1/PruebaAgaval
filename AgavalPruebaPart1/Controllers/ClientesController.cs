using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgavalPruebaPart1.Models.DB;
using AgavalPruebaPart1.Models.DB.ViewModels;
using System.Diagnostics;
using System.Web;

namespace AgavalPruebaPart1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ServiciosAgavalContext _context;
            


        public ClientesController(ServiciosAgavalContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public IActionResult Index()
        {   
            List<Cliente> lista=_context.Clientes.Include(t =>t.oTipoPersona).ToList();
            return View(lista); 
            
        }
        [HttpGet]
        public IActionResult Cliente_Detalle(int idCliente)
        {
            ClienteVM oClienteVM = new ClienteVM()
            {
                oCliente = new Cliente(),
                oListaTipo = _context.Tipospersonas.Select(Tipo => new SelectListItem()
                {
                    Text = Tipo.Nombre,
                    Value = Tipo.Idtipo.ToString()

                }).ToList()
            };

            if (idCliente != 0)
            {

                oClienteVM.oCliente = _context.Clientes.Find(idCliente);
            }


            return View(oClienteVM);
        }



        [HttpPost]
        public IActionResult Cliente_Detalle(ClienteVM oClienteVM)
        {
            if (oClienteVM.oCliente.Idcliente == 0)
            {
                _context.Clientes.Add(oClienteVM.oCliente);

            }
            else
            {
                _context.Clientes.Update(oClienteVM.oCliente);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Clientes");
        }


        [HttpGet]
        public IActionResult Eliminar(int idCliente)
        {

            Cliente oCLiente = _context.Clientes.Include(c => c.oTipoPersona).Where(e => e.Idcliente == idCliente).FirstOrDefault();

            return View(oCLiente);
        }

        [HttpPost]
        public IActionResult Eliminar(Cliente oCliente)
        {

            
            _context.Clientes.Remove(oCliente);
            try
            {
                
                _context.SaveChanges();
                
            }
            catch (Exception)
            {
                
                return RedirectToAction("Index", "Clientes"); ;
            }
            

            return RedirectToAction("Index", "Clientes");
        }



    }
}
