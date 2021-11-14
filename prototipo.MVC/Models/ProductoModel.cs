using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prototipo.MVC.Models
{
    public class ProductoModel
    {
        public int ID_Producto { get; set; }

        public string Nombre { get; set; }

        public string Marca { get; set; }

        public string Descripción { get; set; }

        public int Stock { get; set; }

        public int Available { get; set; }

        public double Precio { get; set; }
    }
}