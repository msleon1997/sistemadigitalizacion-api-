
using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class InformeTutorias
    {
        [Key]
        public int id { get; set; }

        public string Docente_tutor { get; set; }

       
        public string Docente_tutor_est { get; set; }

        public string Empresa_proyecto { get; set; }

        
        public string Periodo_practicas { get; set; }

        
        public string Carrera_est { get; set; }

        
        public string Area_desarrollo { get; set; }

       
        public string Director_carrera { get; set; }

      
        public DateTime Fecha_inicio { get; set; }

        
        public DateTime Fecha_fin { get; set; }

        
        public string Est_cedula { get; set; }

        public string Est_apellidos { get; set; }

       
        public string Est_nombres { get; set; }

        public string Est_ciclo { get; set; }

        public string Introduccion { get; set; }

        public string Descripcion_actividades { get; set; }

       
        public string Conclusion { get; set; }

   
        public string Observaciones { get; set; }

       
        public string Anexos { get; set; }

     
        public string Unidad_academica { get; set; }

   
        public string Componente_tematico { get; set; }

        public string Dia { get; set; }

  
        public string Mes { get; set; }

    
        public string Ano { get; set; }

        public string Tema_consulta { get; set; }

 
        public string RT_Ciclo { get; set; }

        public string Modalidad { get; set; }

    
        public string RT_Estudiante { get; set; }

        public string RT_Cedula_est { get; set; }

     
        public string Responsable_docente_tutor { get; set; }

        
        public string Responsable_ptt { get; set; }

       
        public string Responsable_dic_carrera { get; set; }

     
        public string Accion_1 { get; set; }

        
        public string Accion_2 { get; set; }

     
        public string Accion_3 { get; set; }

  
        public DateTime Fecha_aprovacion1 { get; set; }

      
        public DateTime Fecha_aprovacion2 { get; set; }

      
        public DateTime Fecha_aprovacion3 { get; set; }

    
        public string Firma_1 { get; set; }

   
        public string Firma_2 { get; set; }

    
        public string Firma_3 { get; set; }

        public int users_id { get; set; }

        public int planificacion_id { get; set; }
    }
}
