

using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{

    public class EvaluacionPractica
    {
        [Key]

        public int Id { get; set; }
        public string Empresa_institucion_proyecto { get; set; }
        public string Tipo_Practica { get; set; }
        public string Representante_legal { get; set; }
        public string Tutor_Empresarial { get; set; }
        public string Area_Departamento { get; set; }
        public string Docente { get; set; }
        public string Estudiante { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Supervicion { get; set; }
        public string Hora_Asistencia { get; set; }
        public string Hora_Supervision { get; set; }

        //Responsabilidad y Cumplimiento de Actividades
        public string RCAPregunta1 { get; set; }
        public string RCAPregunta2 { get; set; }
        public string RCAPregunta3 { get; set; }
        public string RCAPregunta4 { get; set; }
        public string RCAPregunta5 { get; set; }
        public int Subtotal1 { get; set; }


        //Área Cognoscitiva
        public string ACPregunta1 { get; set; }
        public string ACPregunta2 { get; set; }
        public string ACPregunta3 { get; set; }
        public string ACPregunta4 { get; set; }
        public string ACPregunta5 { get; set; }
        public int Subtotal2 { get; set; }


        //Habilidades y Destrezas
        public string HDPregunta1 { get; set; }
        public string HDPregunta2 { get; set; }
        public string HDPregunta3 { get; set; }
        public string HDPregunta4 { get; set; }
        public string HDPregunta5 { get; set; }
        public int Subtotal3 { get; set; }


        //Área Actitudinal
        public string AAPregunta1 { get; set; }
        public string AAPregunta2 { get; set; }
        public string AAPregunta3 { get; set; }
        public string AAPregunta4 { get; set; }
        public string AAPregunta5 { get; set; }
        public int Subtotal4 { get; set; }
        public int Total { get; set; }
        public string Observaciones { get; set; }
        public string Rcomendaciones { get; set; }

        public DateTime FechaRegistro { get; set; }
        public int Users_id { get; set; }
    }
        

    
}
