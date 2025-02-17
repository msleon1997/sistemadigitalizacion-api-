using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class ActaCompromiso
    {
        [Key]
        public  int id {get; set;}
        public string Acta_NombresEstudiante { get; set; }
        public string Acta_Carrera { get; set; }
        public string Acta_UnidadAcademica { get; set; }
        public string Acta_NombreEmpresa { get; set; }
        public int users_id { get; set; }




    }
}
