using Dapper;
using MySqlConnector;
using Mysqlx.Prepare;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class PlanificacionRepository : IsisdigitalizacionRepository
    {
        private readonly MysqlConfiguracion _connectionString;
        public PlanificacionRepository(MysqlConfiguracion connectionString) {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection() {
            return new  MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> ActualizarPlanificacion(Planificacion planificacion)
        {
            var db = dbConnection();
            var sql = @"
         UPDATE planificacion SET 
            TP_Carrera = @TP_Carrera, 
            TP_Area = @TP_Area, 
            TP_Docente = @TP_Docente,
            TP_Ciclo = @TP_Ciclo, 
            TP_Categra_Int = @TP_Categra_Int, 
            TP_Proyecto_Integrador = @TP_Proyecto_Integrador, 
            TP_Proyecto_Serv_Com = @TP_Proyecto_Serv_Com, 
            TP_Horas_Pract = @TP_Horas_Pract, 
            TP_Num_Est_Pract = @TP_Num_Est_Pract, 
            TP_Act_Realizar = @TP_Act_Realizar, 
            EstudianteLider = @EstudianteLider,
            TP_Nomina_est_asig = @TP_Nomina_est_asig, 
            TP_Docente_tutor = @TP_Docente_tutor,
            TP_Inst_Emp = @TP_Inst_Emp, 
            TP_Propuesta =  @TP_Propuesta,
            users_id = @users_id,
            matriculacion_id = @matriculacion_id    
        WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                planificacion.TP_Carrera,
                planificacion.TP_Area,
                planificacion.TP_Docente,
                planificacion.TP_Ciclo,
                planificacion.TP_Categra_Int,
                planificacion.TP_Proyecto_Integrador,
                planificacion.TP_Proyecto_Serv_Com,
                planificacion.TP_Horas_Pract,
                planificacion.TP_Num_Est_Pract,
                planificacion.TP_Act_Realizar,
                planificacion.EstudianteLider,
                planificacion.TP_Nomina_est_asig,
                planificacion.TP_Docente_tutor,
                planificacion.TP_Inst_Emp,
                planificacion.TP_Propuesta,
                planificacion.users_id,
                planificacion.matriculacion_id,
                planificacion.id
            });

            return result > 0;
        }




        public async Task<bool> EliminarPlanificacion(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM planificacion WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }


        public async Task<IEnumerable<Planificacion>> GetAllPlanificaciones()
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM planificacion";
            return await db.QueryAsync<Planificacion>(sql, new { });
        }

        public async Task<Planificacion> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM planificacion WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<Planificacion>(sql, new { id = id });
        }

        public async Task<IEnumerable<Planificacion>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM planificacion WHERE users_id = @users_id";
            return await db.QueryAsync<Planificacion>(sql, new { users_id });
        }

        public async Task<IEnumerable<Planificacion>> GetDetailsWithMatriculacion(int id)
        {
            var db = dbConnection();
            var sql = @"
        SELECT p.*, m.carrera 
        FROM planificacion p 
        INNER JOIN matriculacion m ON p.matriculacion_id = m.id 
        WHERE p.id = @id";

            return await db.QueryAsync<Planificacion>(sql, new { id });
        }






        public async Task<bool> InsertarPlanificacion(Planificacion planificacion)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO planificacion(TP_Carrera, TP_Area, TP_Docente, TP_Ciclo, TP_Categra_Int, TP_Proyecto_Integrador, 
                TP_Proyecto_Serv_Com, TP_Horas_Pract, TP_Num_Est_Pract, TP_Act_Realizar, EstudianteLider, TP_Nomina_est_asig, TP_Docente_tutor, TP_Inst_Emp, TP_Propuesta, users_id, matriculacion_id) 
                VALUES 
                (@TP_Carrera, @TP_Area, @TP_Docente, @TP_Ciclo, @TP_Categra_Int, @TP_Proyecto_Integrador, 
                @TP_Proyecto_Serv_Com, @TP_Horas_Pract, @TP_Num_Est_Pract, @TP_Act_Realizar, @EstudianteLider, @TP_Nomina_est_asig, @TP_Docente_tutor, @TP_Inst_Emp, 
                @TP_Propuesta, @users_id, @matriculacion_id) ";

            var result = await db.ExecuteAsync(sql, new
            {

                planificacion.TP_Carrera,
                planificacion.TP_Area,
                planificacion.TP_Docente,
                planificacion.TP_Ciclo,
                planificacion.TP_Categra_Int,
                planificacion.TP_Proyecto_Integrador,
                planificacion.TP_Proyecto_Serv_Com,
                planificacion.TP_Horas_Pract,
                planificacion.TP_Num_Est_Pract,
                planificacion.TP_Act_Realizar,
                planificacion.EstudianteLider,
                planificacion.TP_Nomina_est_asig,
                planificacion.TP_Docente_tutor,
                planificacion.TP_Inst_Emp,
                planificacion.TP_Propuesta,
                planificacion.users_id,
                planificacion.matriculacion_id

            });
            return result > 0;
        }
    }
}
