using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class Planificacion
    {
        [Key]
        public int id { get; set; }
        public string TP_Carrera { get; set; }
        public string TP_Area { get; set; }
        public string TP_Docente { get; set; }
        public string TP_Ciclo { get; set; }
        public string TP_Categra_Int { get; set; }
        public string TP_Proyecto_Integrador { get; set; }
        public string TP_Proyecto_Serv_Com { get; set; }
        public int TP_Horas_Pract { get; set; }
        public int TP_Num_Est_Pract { get; set; }
        public string TP_Act_Realizar { get; set; }
        public string EstudianteLider { get; set; }
        public string TP_Nomina_est_asig { get; set; }
        public string TP_Docente_tutor { get; set; }
        public string TP_Inst_Emp { get; set; }
        public string TP_Propuesta { get; set; }
        public int users_id { get; set; }
        public int matriculacion_id { get; set; }
    }
}
