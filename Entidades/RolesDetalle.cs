using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDetalleWPF.Entidades
{
    class RolesDetalle
    {
        [Key]
        public int RolesDetalleID { get; set; }
        public int RolID { get; set; }
        public int PermisoID { get; set; }
        public bool EsAsignado { get; set; }

        public RolesDetalle(int RolID, int PermisoID)
        {
            RolesDetalleID = 0;
            this.RolID = RolID;
            this.PermisoID = PermisoID;
        }

    }
}
