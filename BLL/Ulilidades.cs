using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDetalleWPF.BLL
{
    class Ulilidades
    {
        public static int ToInt(String valor)
        {
            int retorno = 0;

            int.TryParse(valor, out retorno);

            return retorno;

        }
    }
}
