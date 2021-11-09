using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prototipo.MVC.Models
{
    public class BaseModel
    {
        public List<SelectListItem> Paises { get; set; }
        public List<SelectListItem> Provincias { get; set; }
        public List<SelectListItem> Localidades { get; set; }

        public int PaisId { get; set; }
        public int ProvinciaId { get; set; }
        public int LocalidadId { get; set; }

        public BaseModel()
        {
            this.Paises = new List<SelectListItem>();
            this.Provincias = new List<SelectListItem>();
            this.Localidades = new List<SelectListItem>();
        }
    }
}