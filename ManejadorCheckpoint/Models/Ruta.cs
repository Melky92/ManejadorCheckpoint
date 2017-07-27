using System;
using System.Collections.Generic;

namespace ManejadorCheckpoint.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            TipoVehiculo = new HashSet<TipoVehiculo>();
        }

        public int IdRuta { get; set; }
        public int CantidadDePuntos { get; set; }

        public virtual ICollection<TipoVehiculo> TipoVehiculo { get; set; }
    }
}
