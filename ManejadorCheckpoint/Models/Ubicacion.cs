using System;
using System.Collections.Generic;

namespace ManejadorCheckpoint.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            PuntoControl = new HashSet<PuntoControl>();
        }

        public int IdUbicacion { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
        public string Referencia { get; set; }

        public virtual ICollection<PuntoControl> PuntoControl { get; set; }
    }
}
