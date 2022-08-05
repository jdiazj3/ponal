using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AngualarCrudeOperation.Models
{
    public class turnos
    {
        public int id { get; set; }
        public string consecutivo { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int idOficina { get; set; }
        public int idTipo { get; set; } 
        public string num_documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int idEstado { get; set; } 		
    }
}