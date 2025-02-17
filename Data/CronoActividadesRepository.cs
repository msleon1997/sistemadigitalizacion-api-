using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class CronoActividadesRepository : IsiscronoActividades
    {

        private readonly MysqlConfiguracion _connectionString;

        public CronoActividadesRepository(MysqlConfiguracion connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }




        //empieza los metodos del crud
        public async Task<bool> ActualizaCronoActividades(CronoActividades cronoActividades)
        {
            var db = dbConnection();
            var sql = @"
        UPDATE cronograma_actividades SET 
              CA_Estudiante                 = @CA_Estudiante,
              CA_Actividad                  = @CA_Actividad,
              CA_Tarea                      = @CA_Tarea,
              CA_1raSemana                  = @CA_1raSemana,
              CA1raSem_Lunes                = @CA1raSem_Lunes,
              CA1raSem_Martes               = @CA1raSem_Martes,
              CA1raSem_Miercoles            = @CA1raSem_Miercoles,
              CA1raSem_Jueves               = @CA1raSem_Jueves,
         
              CA_2raSemana                  = @CA_2raSemana,
              CA2raSem_Lunes                = @CA2raSem_Lunes,
              CA2raSem_Martes               = @CA2raSem_Martes,
              CA2raSem_Miercoles            = @CA2raSem_Miercoles,
              CA2raSem_Jueves               = @CA2raSem_Jueves,
      
              CA_3raSemana                  = @CA_3raSemana,
              CA3raSem_Lunes                = @CA3raSem_Lunes,
              CA3raSem_Martes               = @CA3raSem_Martes,
              CA3raSem_Miercoles            = @CA3raSem_Miercoles,
              CA3raSem_Jueves               = @CA3raSem_Jueves,
       
              CA_4raSemana                  = @CA_4raSemana,
              CA4taSem_Lunes                = @CA4taSem_Lunes,
              CA4taSem_Martes               = @CA4taSem_Martes,
              CA4taSem_Miercoles            = @CA4taSem_Miercoles,
              CA4taSem_Jueves               = @CA4taSem_Jueves,
 
              users_id  = @users_id
        WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                cronoActividades.CA_Estudiante,
                cronoActividades.CA_Actividad,
                cronoActividades.CA_Tarea,
                cronoActividades.CA_1raSemana,
                cronoActividades.CA1raSem_Lunes,
                cronoActividades.CA1raSem_Martes,
                cronoActividades.CA1raSem_Miercoles,
                cronoActividades.CA1raSem_Jueves,
              
                cronoActividades.CA_2raSemana,
                cronoActividades.CA2raSem_Lunes,
                cronoActividades.CA2raSem_Martes,
                cronoActividades.CA2raSem_Miercoles,
                cronoActividades.CA2raSem_Jueves,
              
                cronoActividades.CA_3raSemana,
                cronoActividades.CA3raSem_Lunes,
                cronoActividades.CA3raSem_Martes,
                cronoActividades.CA3raSem_Miercoles,
                cronoActividades.CA3raSem_Jueves,
               
                cronoActividades.CA_4raSemana,
                cronoActividades.CA4taSem_Lunes,
                cronoActividades.CA4taSem_Martes,
                cronoActividades.CA4taSem_Miercoles,
                cronoActividades.CA4taSem_Jueves,
               
                cronoActividades.users_id,
                cronoActividades.id
            });

            return result > 0;
        }

        public async Task<bool> EliminarCronoActividades(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM cronograma_actividades WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public async Task<IEnumerable<CronoActividades>> GetAllCronoActividades()
        {
            var db = dbConnection();
            var sql = @"
                SELECT 
                    cronograma_actividades.*, 
                    users.firstname, 
                    users.lastname
                FROM 
                    cronograma_actividades
                LEFT JOIN 
                    users 
                ON 
                    cronograma_actividades.users_id = users.id
                WHERE 
                    users.type = 1;
            ";
            return await db.QueryAsync<CronoActividades>(sql, new { });
        }


        public async Task<CronoActividades> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT 
                cronograma_actividades.*, 
                users.firstname, 
                users.lastname
            FROM 
                cronograma_actividades
            JOIN 
                users 
            ON 
                cronograma_actividades.users_id = users.id
            WHERE 
                cronograma_actividades.id = @id;
";
            return await db.QueryFirstOrDefaultAsync<CronoActividades>(sql, new { id = id });
        }


        public async Task<IEnumerable<CronoActividades>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT 
                cronograma_actividades.*, 
                users.firstname, 
                users.lastname
            FROM 
                cronograma_actividades
            JOIN 
                users 
            ON cronograma_actividades.users_id = users.id
            WHERE users.id = @users_id


            ";
            return await db.QueryAsync<CronoActividades>(sql, new { users_id });
        }


        public async Task<bool> InsertarCronoActividades(CronoActividades cronoActividades)
        {

            var db = dbConnection();
            var sql = @" INSERT cronograma_actividades ( 
              CA_Estudiante               ,
              CA_Actividad                ,  
              CA_Tarea                    ,  
              CA_1raSemana                ,  
              CA1raSem_Lunes              ,  
              CA1raSem_Martes             ,  
              CA1raSem_Miercoles          ,  
              CA1raSem_Jueves             ,  
        
              CA_2raSemana                ,  
              CA2raSem_Lunes              ,  
              CA2raSem_Martes             ,  
              CA2raSem_Miercoles          ,  
              CA2raSem_Jueves             ,  
         
              CA_3raSemana                ,  
              CA3raSem_Lunes              ,  
              CA3raSem_Martes             ,  
              CA3raSem_Miercoles          ,  
              CA3raSem_Jueves             ,  
         
              CA_4raSemana                ,  
              CA4taSem_Lunes              ,  
              CA4taSem_Martes             ,  
              CA4taSem_Miercoles          ,  
              CA4taSem_Jueves             ,  
           
              users_id  
              )
       VALUES (
               @CA_Estudiante,
               @CA_Actividad,
               @CA_Tarea,
               @CA_1raSemana,
               @CA1raSem_Lunes,
               @CA1raSem_Martes,
               @CA1raSem_Miercoles,
               @CA1raSem_Jueves,
              
               @CA_2raSemana,
               @CA2raSem_Lunes,
               @CA2raSem_Martes,
               @CA2raSem_Miercoles,
               @CA2raSem_Jueves,
              
               @CA_3raSemana,
               @CA3raSem_Lunes,
               @CA3raSem_Martes,
               @CA3raSem_Miercoles,
               @CA3raSem_Jueves,
               
               @CA_4raSemana,
               @CA4taSem_Lunes,
               @CA4taSem_Martes,
               @CA4taSem_Miercoles,
               @CA4taSem_Jueves,
                
               @users_id
                )";

            var result = await db.ExecuteAsync(sql, new
            {
                cronoActividades.CA_Estudiante,
                cronoActividades.CA_Actividad,
                cronoActividades.CA_Tarea,
                cronoActividades.CA_1raSemana,
                cronoActividades.CA1raSem_Lunes,
                cronoActividades.CA1raSem_Martes,
                cronoActividades.CA1raSem_Miercoles,
                cronoActividades.CA1raSem_Jueves,
             
                cronoActividades.CA_2raSemana,
                cronoActividades.CA2raSem_Lunes,
                cronoActividades.CA2raSem_Martes,
                cronoActividades.CA2raSem_Miercoles,
                cronoActividades.CA2raSem_Jueves,
       
                cronoActividades.CA_3raSemana,
                cronoActividades.CA3raSem_Lunes,
                cronoActividades.CA3raSem_Martes,
                cronoActividades.CA3raSem_Miercoles,
                cronoActividades.CA3raSem_Jueves,
                
                cronoActividades.CA_4raSemana,
                cronoActividades.CA4taSem_Lunes,
                cronoActividades.CA4taSem_Martes,
                cronoActividades.CA4taSem_Miercoles,
                cronoActividades.CA4taSem_Jueves,
     
                cronoActividades.users_id,
                cronoActividades.id
            });
            return result > 0;
        }


    }
}