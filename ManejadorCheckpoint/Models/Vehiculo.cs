using System;
using System.Collections.Generic;

namespace ManejadorCheckpoint.Models
{
    public partial class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Placa { get; set; }
        public int IdTipoVehiculo { get; set; }

        public virtual TipoVehiculo IdTipoVehiculoNavigation { get; set; }
    }
}
