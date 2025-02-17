using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class ActividadesPracticas
    {
        [Key]
      public int id {  get; set; }

      public string App_Empresa_Institucion { get; set; }
      public string App_Direccion           { get; set; }
      public string App_Telefono            { get; set; }
      public string App_Email               { get; set; }
      public string App_Area_dep_proyect    { get; set; }
      public string App_Asignatura_Catedra  { get; set; }
      public string App_Tutor_ext           { get; set; }
      public string App_Cargo { get; set; }

     

        public string App_Convenio { get; set; }
        public DateTime App_Fecha_firma_convenio { get; set; }
        public DateTime App_Fecha_termino_convenio { get; set; }
        public string App_Nom_est { get; set; }
        public string App_Cedula_est { get; set; }
        public string App_Celular_est { get; set; }
        public string App_Email_est { get; set; }
        public string App_Nombre_doc { get; set; }
        public string App_Cedula_doc { get; set; }
        public string App_Email_doc { get; set; }
        public DateTime App_Fecha_ini { get; set; }
        public DateTime App_Fecha_fin { get; set; }
        public int users_id { get; set; }
        
    }
}
