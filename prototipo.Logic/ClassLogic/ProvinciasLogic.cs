using prototipo.Entities;
using prototipo.Logic.InterfaceLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototipo.Logic.ClassLogic
{
    public class ProvinciasLogic : BaseLogic, IABMLogic<Provincias>
    {
        public void Add(Provincias addItem)
        {
            try
            {
                context.Provincias.Add(addItem);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
               // throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var provinciasDelete = context.Provincias.Find(id);
                if (provinciasDelete != null)
                {
                    //Borrado fisico
                    //context.Provincias.Remove(provinciasDelete);
                    provinciasDelete.Available = 0;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe la provincia a eliminar.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Find(int id)
        {
            try
            {
                bool output = false;
                var bufferProvincias = context.Provincias.Find(id);
                if (bufferProvincias != null)
                {
                    output = true;
                }
                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Provincias> GetAll()
        {
            try
            {
                return context.Provincias.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Provincias updateItem)
        {
            try
            {
                var bufferProvincias = context.Provincias.Find(updateItem.ProvinciaID);
                if (bufferProvincias != null)
                {
                    bufferProvincias.ProvinciaName = updateItem.ProvinciaName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe la provincia a modificar.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
