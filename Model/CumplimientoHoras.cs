using System;
using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class CumplimientoHoras
    {
        [Key]
        public int Id { get; set; }
        public string Empresa_institucion_proyecto { get; set; }
        public string Docente_tutor { get; set; }
        public string Tutor_Externo { get; set; }
        public string Estudiante { get; set; }
        public string  Fecha { get; set; }
        public string Hora_Entrada { get; set; } // Cambiado a TimeSpan
        public string Hora_Salida { get; set; }  // Cambiado a TimeSpan
        public string Actividades_Realizadas { get; set; }
        public int Users_id { get; set; }
    }
}
