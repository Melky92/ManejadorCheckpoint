using System;
using System.Collections.Generic;

namespace ManejadorCheckpoint.Models
{
    public partial class RegistroPunto
    {
        public int Id { get; set; }
        public int IdVehiculo { get; set; }
        public int IdPunto { get; set; }
        public DateTime FechaHora { get; set; }
        public String Debug { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
