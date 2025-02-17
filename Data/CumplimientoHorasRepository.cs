using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class CumplimientoHorasRepository : IsisCumplimientoHorasRepository
    {
        private readonly MysqlConfiguracion _connectionString;

        public CumplimientoHorasRepository(MysqlConfiguracion connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        //empieza los metodos del crud
        public async Task<bool> ActualizarCumplimientoHoras(CumplimientoHoras cumplimientoHoras)
        {
            var db = dbConnection();
            var sql = @"
        UPDATE cumplimiento_horas_pract SET 
              Empresa_institucion_proyecto = @Empresa_institucion_proyecto,
              Docente_tutor = @Docente_tutor,
              Tutor_Externo = @Tutor_Externo,
              Estudiante = @Estudiante,
              Fecha = @Fecha,
              Hora_Entrada = @Hora_Entrada,
              Hora_Salida = @Hora_Salida,
              Actividades_Realizadas = @Actividades_Realizadas,
              users_id = @users_id
              
        WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                cumplimientoHoras.Empresa_institucion_proyecto,
                cumplimientoHoras.Docente_tutor,
                cumplimientoHoras.Tutor_Externo,
                cumplimientoHoras.Estudiante,
                cumplimientoHoras.Fecha,
                cumplimientoHoras.Hora_Entrada,
                cumplimientoHoras.Hora_Salida,
                cumplimientoHoras.Actividades_Realizadas,
                cumplimientoHoras.Users_id,
                cumplimientoHoras.Id
            });

            return result > 0;
        }


        public async Task<bool> EliminarCumplimientoHoras(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM cumplimiento_horas_pract WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }



        public async Task<IEnumerable<CumplimientoHoras>> GetAllCumplimientoHoras()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM cumplimiento_horas_pract";
            return await db.QueryAsync<CumplimientoHoras>(sql, new { });

        }

        public async Task<CumplimientoHoras> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM cumplimiento_horas_pract WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<CumplimientoHoras>(sql, new { id = id });
        }

        public async Task<IEnumerable<CumplimientoHoras>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM cumplimiento_horas_pract WHERE users_id = @users_id";
            return await db.QueryAsync<CumplimientoHoras>(sql, new { users_id });
        }


        public async Task<bool> InsertarCumplimientoHoras(CumplimientoHoras cumplimientoHoras)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO cumplimiento_horas_pract (
                    Empresa_institucion_proyecto,
                    Docente_tutor,
                    Tutor_Externo,
                    Estudiante,
                    Fecha,
                    Hora_Entrada,
                    Hora_Salida,
                    Actividades_Realizadas,
                    users_id
                ) 
                VALUES (
                    @Empresa_institucion_proyecto,
                    @Docente_tutor,
                    @Tutor_Externo,
                    @Estudiante,
                    @Fecha,
                    @Hora_Entrada,
                    @Hora_Salida,
                    @Actividades_Realizadas,
                    @Users_id)";

            var result = await db.ExecuteAsync(sql, new
            {
                cumplimientoHoras.Empresa_institucion_proyecto,
                cumplimientoHoras.Docente_tutor,
                cumplimientoHoras.Tutor_Externo,
                cumplimientoHoras.Estudiante,
                cumplimientoHoras.Fecha,
                cumplimientoHoras.Hora_Entrada,
                cumplimientoHoras.Hora_Salida,
                cumplimientoHoras.Actividades_Realizadas,
                cumplimientoHoras.Users_id
            });

            return result > 0;
        }








    }
}
