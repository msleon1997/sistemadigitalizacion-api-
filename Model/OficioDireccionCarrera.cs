using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class OficioDireccionCarrera
    {
        [Key]
        public int id { get; set; }
        public DateTime odc_fecha { get; set;}
        public int odc_numero { get; set;}
        public string odc_repre_legal { get; set; }
        public string odc_nom_est {  get; set; }
        public string odc_cedula_est { get; set; }
        public string odc_ciclo_est { get; set; }
        public string odc_unidad_acade {  get; set; }
        public string odc_carrera_est { get; set; }
        public string odc_area {  get; set; }
        public int odc_num_horas { get; set; }
        public string odc_director_carrera {  get; set; }
        public string odc_nombre_per_aut { get; set; }
        public string odc_per_aut_cargo { get; set; }
        public string odc_autorizacion { get; set; }
        public string odc_nombre_tutor { get; set; }
        public int users_id { get; set; }


    }
}
