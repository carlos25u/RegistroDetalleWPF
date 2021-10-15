using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDetalleWPF.Entidades
{
    class Permisos
    {
        [Key]
        public int PermisoID { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }

        [ForeignKey("PermisoID")]
        public virtual List<RolesDetalle> RolesDetalle { get; set; }

        public Permisos()
        {
            PermisoID = 0;
            RolesDetalle = new List<RolesDetalle>();
        }

    }
}
