using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class MatriculacionRepository :IsisMatriculacionRepository
    {
        private readonly MysqlConfiguracion _connectionString;

        public MatriculacionRepository(MysqlConfiguracion connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //empieza los metodos del crud
        public async Task<bool> ActualizarMatriculacion(Matriculacion matriculacion)
        {
            var db = dbConnection();
            var sql = @"
        UPDATE matriculacion SET 
            cedula_est = @cedula_est, 
            firstname_est = @firstname_est, 
            lastname_est = @lastname_est,
            carrera = @carrera, 
            area = @area, 
            ciclo = @ciclo, 
            nombre_proyecto = @nombre_proyecto,
            email_est = @email_est, 
            telefono = @telefono, 
            docente_tutor = @docente_tutor, 
            nombre_institucion = @nombre_institucion, 
            propuesta = @propuesta, 
            users_id = @users_id
        WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                matriculacion.cedula_est,
                matriculacion.firstname_est,
                matriculacion.lastname_est,
                matriculacion.carrera,
                matriculacion.area,
                matriculacion.ciclo,
                matriculacion.nombre_proyecto,
                matriculacion.email_est,
                matriculacion.telefono,
                matriculacion.docente_tutor,
                matriculacion.nombre_institucion,
                matriculacion.propuesta,
                matriculacion.users_id,
                matriculacion.id
            });

            return result > 0;
        }


        public async Task<bool> EliminarMatriculacion(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM matriculacion WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public async Task<IEnumerable<Matriculacion>> GetAllMatriculacion()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM matriculacion";
            return await db.QueryAsync<Matriculacion>(sql, new { });

        }

        public async Task<Matriculacion> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM matriculacion WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<Matriculacion>(sql, new { id = id });
        }

        public async Task<IEnumerable<Matriculacion>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM matriculacion WHERE users_id = @users_id";
            return await db.QueryAsync<Matriculacion>(sql, new { users_id });
        }



        public async Task<bool> InsertarMatriculacion(Matriculacion matriculacion)
        {
            var db = dbConnection();
            var sql = @" INSERT  INTO matriculacion(
                        cedula_est,
                        firstname_est,
                        lastname_est,
                        carrera,
                        area,
                        ciclo,
                        nombre_proyecto,
                        email_est,
                        telefono,
                        docente_tutor,
                        nombre_institucion,
                        propuesta,
                        users_id

                        ) 
                        VALUES 
                        (
                        @cedula_est, 
                        @firstname_est, 
                        @lastname_est, 
                        @carrera, 
                        @area, 
                        @ciclo, 
                        @nombre_proyecto, 
                        @email_est, 
                        @telefono, 
                        @docente_tutor, 
                        @nombre_institucion, 
                        @propuesta,
                        @users_id) ";

            var result = await db.ExecuteAsync(sql, new
            {
                matriculacion.cedula_est,
                matriculacion.firstname_est,
                matriculacion.lastname_est,
                matriculacion.carrera,
                matriculacion.area,
                matriculacion.ciclo,
                matriculacion.nombre_proyecto,
                matriculacion.email_est,
                matriculacion.telefono,
                matriculacion.docente_tutor,
                matriculacion.nombre_institucion,
                matriculacion.propuesta,
                matriculacion.users_id
               
            });

            return result > 0;
        }






    }
}
