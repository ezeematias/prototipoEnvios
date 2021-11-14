using prototipo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prototipo.MVC.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Producto
        PrototipoServices.ServiceClient client = new PrototipoServices.ServiceClient();

        public ActionResult Index()
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            var list = client.GetAll();

            foreach (var item in list)
            {
                ProductoModel auxProducto = new ProductoModel
                {
                    ID_Producto = item.ID_Producto,
                    Nombre = item.Nombre,
                    Marca = item.Marca,
                    Descripción = item.Descripción,
                    Precio = item.Precio,
                    Stock = item.Stock,
                    Available = item.Available
                };
                productos.Add(auxProducto);
            }
            return View(productos);
        }

        [HttpGet]
        public PartialViewResult CreateProducto()
        {
            return PartialView("_CreateProductoPartial");
        }

        [HttpPost]
        public ActionResult CreateProducto(PrototipoServices.Producto model)
        {
            model.Available = 1;
            if (model != null)
            {
                client.Add(model);
                return RedirectToAction("Index", "Productos");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public PartialViewResult EditProducto(int id)
        {
            var model = client.GetById(id);
            ViewBag.ID_Producto = model.ID_Producto;
            ViewBag.Nombre = model.Nombre;
            ViewBag.Marca = model.Marca;
            ViewBag.Descripción = model.Descripción;
            ViewBag.Precio = model.Precio;
            ViewBag.Stock = model.Stock;
            ViewBag.Available = model.Available;
            return PartialView("_EditProductoPartial");
        }

        [HttpPost]
        public ActionResult EditProducto(PrototipoServices.Producto model)
        {            
            client.Update(model);
            return RedirectToAction("Index", "Productos");
        }

        public ActionResult DeleteProducto(int id)
        {
            try
            {
                client.Delete(id);
                return RedirectToAction("Index", "Productos");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}