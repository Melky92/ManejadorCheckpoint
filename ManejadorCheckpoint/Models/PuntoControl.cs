using System;
using System.Collections.Generic;

namespace ManejadorCheckpoint.Models
{
    public partial class PuntoControl
    {
        public int IdPuntoControl { get; set; }
        public string DescripcionDispositivo { get; set; }
        public int IdUbicacion { get; set; }

        public virtual Ubicacion IdUbicacionNavigation { get; set; }
    }
}
