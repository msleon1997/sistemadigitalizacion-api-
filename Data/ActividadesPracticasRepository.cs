using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class ActividadesPracticasRepository: IsisactividadesPracticas

       
    {
        private readonly MysqlConfiguracion _connectionString;

        public ActividadesPracticasRepository(MysqlConfiguracion connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        //empieza los metodos del crud
        public async Task<bool> ActualizarActividadesPracticas(ActividadesPracticas actividadesPracticas)
        {
            var db = dbConnection();
            var sql = @"
        UPDATE actividades_practicas_pre SET 
              App_Empresa_Institucion = @App_Empresa_Institucion,
              App_Direccion = @App_Direccion,
              App_Telefono = @App_Telefono,
              App_Email = @App_Email,
              App_Area_dep_proyect = @App_Area_dep_proyect,
              App_Asignatura_Catedra = @App_Asignatura_Catedra,
              App_Tutor_ext = @App_Tutor_ext,
              App_Cargo = @App_Cargo,
              App_Convenio = @App_Convenio,
              App_Fecha_firma_convenio = @App_Fecha_firma_convenio,
              App_Fecha_termino_convenio = @App_Fecha_termino_convenio,
              App_Nom_est = @App_Nom_est,
              App_Cedula_est = @App_Cedula_est,
              App_Celular_est = @App_Celular_est,
              App_Email_est = @App_Email_est,
              App_Nombre_doc = @App_Nombre_doc,
              App_Cedula_doc = @App_Cedula_doc,
              App_Email_doc = @App_Email_doc,
              App_Fecha_ini = @App_Fecha_ini,
              App_Fecha_fin = @App_Fecha_fin,
              users_id = @users_id
              
        WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                actividadesPracticas.App_Empresa_Institucion,
                actividadesPracticas.App_Direccion,
                actividadesPracticas.App_Telefono,
                actividadesPracticas.App_Email,
                actividadesPracticas.App_Area_dep_proyect,
                actividadesPracticas.App_Asignatura_Catedra,
                actividadesPracticas.App_Tutor_ext,
                actividadesPracticas.App_Cargo,
                actividadesPracticas.App_Convenio,
                actividadesPracticas.App_Fecha_firma_convenio,
                actividadesPracticas.App_Fecha_termino_convenio,
                actividadesPracticas.App_Nom_est,
                actividadesPracticas.App_Cedula_est,
                actividadesPracticas.App_Celular_est,
                actividadesPracticas.App_Email_est,
                actividadesPracticas.App_Nombre_doc,
                actividadesPracticas.App_Cedula_doc,
                actividadesPracticas.App_Email_doc,
                actividadesPracticas.App_Fecha_ini,
                actividadesPracticas.App_Fecha_fin,
                actividadesPracticas.users_id,
                actividadesPracticas.id
            });

            return result > 0;
        }



        public async Task<bool> EliminarActividadesPracticas(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM actividades_practicas_pre WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }



        public async Task<IEnumerable<ActividadesPracticas>> GetAllActividadesPracticas()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM actividades_practicas_pre";
            return await db.QueryAsync<ActividadesPracticas>(sql, new { });

        }

        public async Task<ActividadesPracticas> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM actividades_practicas_pre WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<ActividadesPracticas>(sql, new { id = id });
        }

        public async Task<IEnumerable<ActividadesPracticas>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM actividades_practicas_pre WHERE users_id = @users_id";
            return await db.QueryAsync<ActividadesPracticas>(sql, new { users_id });
        }

        public async Task<bool> InsertarActividadesPracticas(ActividadesPracticas actividadesPracticas)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO actividades_practicas_pre (
              App_Empresa_Institucion,
              App_Direccion,
              App_Telefono, 
              App_Email, 
              App_Area_dep_proyect, 
              App_Asignatura_Catedra, 
              App_Tutor_ext,
              App_Cargo,
              App_Convenio, 
              App_Fecha_firma_convenio, 
              App_Fecha_termino_convenio, 
              App_Nom_est, 
              App_Cedula_est, 
              App_Celular_est, 
              App_Email_est, 
              App_Nombre_doc, 
              App_Cedula_doc,
              App_Email_doc, 
              App_Fecha_ini, 
              App_Fecha_fin, 
              users_id
             ) 
               VALUES 
                (@App_Empresa_Institucion,@App_Direccion,@App_Telefono,@App_Email, @App_Area_dep_proyect,@App_Asignatura_Catedra,
                       @App_Tutor_ext,@App_Cargo,
                       @App_Convenio,@App_Fecha_firma_convenio,@App_Fecha_termino_convenio,@App_Nom_est, @App_Cedula_est,
                        @App_Celular_est,@App_Email_est,@App_Nombre_doc,@App_Cedula_doc,@App_Email_doc,@App_Fecha_ini,
                        @App_Fecha_fin,@users_id)";

            var result = await db.ExecuteAsync(sql, new
            {
                actividadesPracticas.App_Empresa_Institucion,
                actividadesPracticas.App_Direccion,
                actividadesPracticas.App_Telefono,
                actividadesPracticas.App_Email,
                actividadesPracticas.App_Area_dep_proyect,
                actividadesPracticas.App_Asignatura_Catedra,
                actividadesPracticas.App_Tutor_ext,
                actividadesPracticas.App_Cargo,
                actividadesPracticas.App_Convenio,
                actividadesPracticas.App_Fecha_firma_convenio,
                actividadesPracticas.App_Fecha_termino_convenio,
                actividadesPracticas.App_Nom_est,
                actividadesPracticas.App_Cedula_est,
                actividadesPracticas.App_Celular_est,
                actividadesPracticas.App_Email_est,
                actividadesPracticas.App_Nombre_doc,
                actividadesPracticas.App_Cedula_doc,
                actividadesPracticas.App_Email_doc,
                actividadesPracticas.App_Fecha_ini,
                actividadesPracticas.App_Fecha_fin,
                actividadesPracticas.users_id,
                actividadesPracticas.id
            });

            return result > 0;
        }

    }


}

