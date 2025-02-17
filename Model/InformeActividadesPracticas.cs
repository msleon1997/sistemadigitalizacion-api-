using System;
using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class InformeActividadesPracticas
    {
        // Datos de la tabla actividades_practicas_pre
        [Key]
        public int id_practica { get; set; }
        public string empresa_institucion { get; set; }
        public string direccion_empresa { get; set; }
        public string telefono_empresa { get; set; }
        public string email_empresa { get; set; }
        public string area_departamento_proyecto { get; set; }
        public string asignatura_catedra { get; set; }
        public string tutor_externo { get; set; }
        public string cargo_tutor { get; set; }
        public string convenio { get; set; }
        public DateTime fecha_firma_convenio { get; set; }
        public DateTime fecha_termino_convenio { get; set; }
        public string estudiante { get; set; }
        public string cedula_estudiante { get; set; }
        public string celular_estudiante { get; set; }
        public string email_estudiante { get; set; }
        public string docente { get; set; }
        public string cedula_docente { get; set; }
        public string email_docente { get; set; }
        public DateTime fecha_inicio_practica { get; set; }
        public DateTime fecha_fin_practica { get; set; }
        public int usuario_id { get; set; }

        // Datos de la tabla cronograma_actividades
        public int id_cronograma { get; set; }
        public string actividad_cronograma { get; set; }
        public string tarea_cronograma { get; set; }
        public string primera_semana { get; set; }
        public string primera_semana_lunes { get; set; }
        public string primera_semana_martes { get; set; }
        public string primera_semana_miercoles { get; set; }
        public string primera_semana_jueves { get; set; }
        public string segunda_semana { get; set; }
        public string segunda_semana_lunes { get; set; }
        public string segunda_semana_martes { get; set; }
        public string segunda_semana_miercoles { get; set; }
        public string segunda_semana_jueves { get; set; }
        public string tercera_semana { get; set; }
        public string tercera_semana_lunes { get; set; }
        public string tercera_semana_martes { get; set; }
        public string tercera_semana_miercoles { get; set; }
        public string tercera_semana_jueves { get; set; }
        public string cuarta_semana { get; set; }
        public string cuarta_semana_lunes { get; set; }
        public string cuarta_semana_martes { get; set; }
        public string cuarta_semana_miercoles { get; set; }
        public string cuarta_semana_jueves { get; set; }

        // Datos de la tabla cumplimiento_horas_pract
        public int id_cumplimiento { get; set; }
        public string proyecto_empresa { get; set; }
        public string docente_tutor { get; set; }
        public string tutor_externo_horas { get; set; }
        public string estudiante_horas { get; set; }
        public string fecha_horas { get; set; }
        public string hora_entrada { get; set; }
        public string hora_salida { get; set; }
        public string actividades_realizadas { get; set; }


        public int id_acta { get; set; }
        public string Acta_NombresEstudiante { get; set; }
        public string Acta_Carrera { get; set; }
        public string Acta_UnidadAcademica { get; set; }
        public string Acta_NombreEmpresa { get; set; }
       
      



    }
}
