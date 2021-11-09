using prototipo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototipo.Logic.ClassLogic
{    public class BaseLogic
    {
        protected readonly PaisesContext context;

        public BaseLogic()
        {
            context = new PaisesContext();
        }
    }
}
