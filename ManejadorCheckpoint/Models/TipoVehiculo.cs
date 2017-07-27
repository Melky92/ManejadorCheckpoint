using System;
using System.Collections.Generic;

namespace ManejadorCheckpoint.Models
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdTipoVehiculo { get; set; }
        public string Etiqueta { get; set; }
        public int IdRuta { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
        public virtual Ruta IdRutaNavigation { get; set; }
    }
}
