using Microsoft.EntityFrameworkCore.Metadata;

namespace sisdigitalizacion.Data
{
    public class MysqlConfiguracion
    {
        public  MysqlConfiguracion (string connectionString) { 
        
            ConnectionString  = connectionString;
        }
       public string ConnectionString { get; set; }
    }
}
