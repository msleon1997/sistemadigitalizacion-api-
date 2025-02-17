using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class EvaluacionFinalCertificado
    
    {
        [Key]

        public int Id { get; set; }

        public string Nom_director_carrera { get; set; }
        public string Nom_est { get; set; }
        public string Num_cedula { get; set;}
        public string Area_desarrollo { get; set; }
        public string Duracion_horas { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Representante_empresa { get; set; }
        public string Est_nombre { get; set; }
        public string Est_carrera { get; set; }
        public string Est_ciclo { get; set; }

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
        public string Recomendaciones { get; set; }

        public DateTime FechaRegistro { get; set; }
        public string Nombre_Tutor_empresa { get; set; }
        public string Nombre_empresa { get; set; }
        public string logo_empresa { get; set; }
        public int users_id { get; set; }
    }


}
