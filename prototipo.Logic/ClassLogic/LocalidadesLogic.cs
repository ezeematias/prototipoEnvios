using prototipo.Entities;
using prototipo.Logic.InterfaceLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototipo.Logic.ClassLogic
{
    public class LocalidadesLogic : BaseLogic, IABMLogic<Localidades>
    {
        public void Add(Localidades addItem)
        {
            try
            {
                context.Localidades.Add(addItem);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var localidadDelete = context.Localidades.Find(id);
                if (localidadDelete != null)
                {
                    //Borrado fisico
                    //context.Localidades.Remove(localidadDelete);
                    localidadDelete.Available = 0;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe la localidad a eliminar.");
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
                var bufferLocalidades = context.Localidades.Find(id);
                if (bufferLocalidades != null)
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

        public List<Localidades> GetAll()
        {
            try
            {
                return context.Localidades.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Localidades updateItem)
        {
            try
            {
                var bufferLocalidades = context.Localidades.Find(updateItem.localidadID);
                if (bufferLocalidades != null)
                {
                    bufferLocalidades.LocalidadName = updateItem.LocalidadName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe la localidad a modificar.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
