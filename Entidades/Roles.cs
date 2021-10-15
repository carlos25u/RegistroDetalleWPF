using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDetalleWPF.Entidades
{
    class Roles
    {
        [Key]
        public int RolID { get; set; }
        public String Descripcion { get; set; }
        public bool EsActivo { get; set; }

        [ForeignKey("RolID")]
        public virtual List<RolesDetalle> RolesDetalle { get; set; }

        public Roles()
        {
            RolID = 0;
            RolesDetalle = new List<RolesDetalle>();
        }

    }
}
