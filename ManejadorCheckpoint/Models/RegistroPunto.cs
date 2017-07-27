using System;
using System.Collections.Generic;

namespace ManejadorCheckpoint.Models
{
    public partial class RegistroPunto
    {
        public int IdVehiculo { get; set; }
        public int IdPunto { get; set; }
        public int DateTime { get; set; }
    }
}
