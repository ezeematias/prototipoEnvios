using prototipo.Entities;
using prototipo.Logic.InterfaceLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototipo.Logic.ClassLogic
{
    public class PaisesLogic : BaseLogic, IABMLogic<Paises>
    {
        public void Add(Paises addItem)
        {
            try
            {
                context.Paises.Add(addItem);
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
                var paisDelete = context.Paises.Find(id);
                if (paisDelete != null)
                {
                    //Borrado fisico
                    //context.Paises.Remove(paisDelete);
                    paisDelete.Available = 0;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe el pais para eliminar.");
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
                var bufferPais = context.Paises.Find(id);
                if (bufferPais != null)
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

        public List<Paises> GetAll()
        {
            try
            {
                return context.Paises.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Paises updateItem)
        {
            try
            {
                var bufferPais = context.Paises.Find(updateItem.PaisID);
                if (bufferPais != null)
                {
                    bufferPais.PaisName = updateItem.PaisName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe el pais a modificar.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
