using System.ComponentModel.DataAnnotations;

namespace sisdigitalizacion.Model
{
    public class Matriculacion
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string cedula_est { get; set; }

        [Required]
        [StringLength(45)]
        public string firstname_est { get; set; }

        [Required]
        [StringLength(45)]
        public string lastname_est { get; set; }

        [Required]
        [StringLength(100)]
        public string carrera { get; set; }

        [Required]
        public string area { get; set; }

        [Required]
        public string ciclo { get; set; }

        [Required]
        public string nombre_proyecto { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string email_est { get; set; }

        [Required]
        [StringLength(10)]
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string docente_tutor { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_institucion { get; set; }

        [Required]
        public string propuesta { get; set; }

        [Required]
        public int users_id { get; set; }
    }
}
