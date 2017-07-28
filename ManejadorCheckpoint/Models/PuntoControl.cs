using System;
using System.Collections.Generic;

namespace ManejadorCheckpoint.Models
{
    public partial class PuntoControl
    {
        public int IdPuntoControl { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
        public string Referencia { get; set; }
        public string DescripcionDispositivo { get; set; }
    }
}
