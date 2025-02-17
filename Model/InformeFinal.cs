using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class InformeFinal
    {
        [Key]
        public int Id { get; set; }

        // Información General
        public string Empresa_Institucion_Proyecto { get; set; }
        public string Tutor_externo { get; set; }
        public string Estudiante_grupo { get; set; }
        public string Docente_tutor { get; set; }
        public string Periodo_practicas { get; set; }

        // Contenidos del Informe
        public string Introduccion { get; set; }
        public string Obj_general { get; set; }
        public string Obj_especifico { get; set; }
        public string Justificacion { get; set; }
        public string Antecedentes { get; set; }
        public string Mision_inst { get; set; }
        public string Vision_inst { get; set; }
        public string Obj_inst { get; set; }
        public string Valores_inst { get; set; }
        public string Bene_directos { get; set; }
        public string Bene_indirectos { get; set; }
        public string RA_asignatura { get; set; }
        public string RA_resultado_aprendizaje { get; set; }
        public string RA_perfil_egreso { get; set; }
        public string Evaluacion_impacto { get; set; }
        public string Detalle_actividades { get; set; }

        // Autoevaluación del Estudiante
        public string AUTOEVL_estudiante { get; set; }

        // Evaluación de Áreas
        public string AUTOEVL_pregunta1 { get; set; }

        public string AUTOEVL_pregunta2 { get; set; }


        public string AUTOEVL_pregunta3 { get; set; }
 

        public string AUTOEVL_pregunta4 { get; set; }

        public string AUTOEVL_pregunta5 { get; set; }
        public string AUTOEVL_pregunta6 { get; set; }
        public string AUTOEVL_pregunta7 { get; set; }
        public string AUTOEVL_pregunta8 { get; set; }
        public string AUTOEVL_pregunta9 { get; set; }
        public string AUTOEVL_pregunta10 { get; set; }
        public string AUTOEVL_pregunta11 { get; set; }
        public string AUTOEVL_pregunta12 { get; set; }
        public string AUTOEVL_pregunta13 { get; set; }
        public string AUTOEVL_pregunta14 { get; set; }
        public string AUTOEVL_pregunta15 { get; set; }
        public string AUTOEVL_pregunta16 { get; set; }
        public string AUTOEVL_pregunta17 { get; set; }
        public string AUTOEVL_pregunta18 { get; set; }

        // Conclusiones y Anexos
        public string Conclusiones { get; set; }
        public string Recomendaciones { get; set; }
        public string Biografia { get; set; }
        public string Anexos { get; set; }
        public string Aprobaciones { get; set; }

        // Relación con usuarios
        public int Users_id { get; set; }
        public int Planificacion_id { get; set; }
    }
}
