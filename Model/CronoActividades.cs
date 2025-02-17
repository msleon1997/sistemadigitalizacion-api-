using System;
using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class CronoActividades
    {
        [Key]
        public int id { get; set; }
        public string CA_Estudiante { get; set; }
        public string CA_Actividad { get; set; }
        public string CA_Tarea { get; set; }

        // Información para la primera semana
        public string CA_1raSemana { get; set; }
        public string CA1raSem_Lunes { get; set; }
        public string CA1raSem_Martes { get; set; }
        public string CA1raSem_Miercoles { get; set; }
        public string CA1raSem_Jueves { get; set; }
    

        // Información para la segunda semana
        public string CA_2raSemana { get; set; }
        public string CA2raSem_Lunes { get; set; }
        public string CA2raSem_Martes { get; set; }
        public string CA2raSem_Miercoles { get; set; }
        public string CA2raSem_Jueves { get; set; }
     

        // Información para la tercera semana
        public string CA_3raSemana { get; set; }
        public string CA3raSem_Lunes { get; set; }
        public string CA3raSem_Martes { get; set; }
        public string CA3raSem_Miercoles { get; set; }
        public string CA3raSem_Jueves { get; set; }
   

        // Información para la cuarta semana
        public string CA_4raSemana { get; set; }
        public string CA4taSem_Lunes { get; set; }
        public string CA4taSem_Martes { get; set; }
        public string CA4taSem_Miercoles { get; set; }
        public string CA4taSem_Jueves { get; set; }
  
        public int users_id { get; set; }


    }
}
