using Dapper;
using MySqlConnector;
using Mysqlx.Prepare;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class OficioDireccionCarreraRepository : IsisoficioDireccionCarreraRepository
    {
        private readonly MysqlConfiguracion _connectionString;
        public OficioDireccionCarreraRepository(MysqlConfiguracion connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        //empieza los metodos del crud
        public async Task<bool> ActualizarOficioDireccionCarrera(OficioDireccionCarrera oficiodireccioncarrera)
        {
            var db = dbConnection();
            var sql = @"
        UPDATE oficio_direccion_carrera SET 
            odc_fecha = @odc_fecha, 
            odc_numero = @odc_numero, 
            odc_repre_legal = @odc_repre_legal,
            odc_nom_est = @odc_nom_est, 
            odc_cedula_est = @odc_cedula_est, 
            odc_ciclo_est = @odc_ciclo_est, 
            odc_carrera_est = @odc_carrera_est,
            odc_unidad_acade = @odc_unidad_acade, 
            odc_area = @odc_area, 
            odc_num_horas = @odc_num_horas, 
            odc_director_carrera = @odc_director_carrera, 
            odc_nombre_per_aut = @odc_nombre_per_aut, 
            odc_per_aut_cargo = @odc_per_aut_cargo,
            odc_autorizacion = @odc_autorizacion, 
            odc_nombre_tutor =  @odc_nombre_tutor,
            users_id = @users_id
        WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                oficiodireccioncarrera.odc_fecha,
                oficiodireccioncarrera.odc_numero,
                oficiodireccioncarrera.odc_repre_legal,
                oficiodireccioncarrera.odc_nom_est,
                oficiodireccioncarrera.odc_cedula_est,
                oficiodireccioncarrera.odc_ciclo_est,
                oficiodireccioncarrera.odc_carrera_est,
                oficiodireccioncarrera.odc_unidad_acade,
                oficiodireccioncarrera.odc_area,
                oficiodireccioncarrera.odc_num_horas,
                oficiodireccioncarrera.odc_director_carrera,
                oficiodireccioncarrera.odc_nombre_per_aut,
                oficiodireccioncarrera.odc_per_aut_cargo,
                oficiodireccioncarrera.odc_autorizacion,
                oficiodireccioncarrera.odc_nombre_tutor,
                oficiodireccioncarrera.users_id,
                oficiodireccioncarrera.id
            });

            return result > 0;
        }




        public async Task<bool> EliminarOficioDireccionCarrera(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM oficio_direccion_carrera WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public async Task<IEnumerable<OficioDireccionCarrera>> GetAllOficioDireccionCarrera()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM oficio_direccion_carrera";
            return await db.QueryAsync<OficioDireccionCarrera>(sql, new { });

        }

        public async Task<OficioDireccionCarrera> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM oficio_direccion_carrera WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<OficioDireccionCarrera>(sql, new { id = id });
        }

        public async Task<IEnumerable<OficioDireccionCarrera>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM oficio_direccion_carrera WHERE users_id = @users_id";
            return await db.QueryAsync<OficioDireccionCarrera>(sql, new { users_id });
        }

        public async Task<bool> InsertarOficioDireccionCarrera(OficioDireccionCarrera oficiodireccioncarrera)
        {
            var db = dbConnection();
            var sql = @" INSERT  INTO oficio_direccion_carrera(
                        odc_fecha, odc_numero, odc_repre_legal, odc_nom_est, odc_cedula_est, odc_ciclo_est, odc_carrera_est, 
                        odc_unidad_acade, odc_area, odc_num_horas, odc_director_carrera, odc_nombre_per_aut, 
                        odc_per_aut_cargo, odc_autorizacion, odc_nombre_tutor, users_id) 
                        VALUES 
                        (@odc_fecha, @odc_numero, @odc_repre_legal, @odc_nom_est, @odc_cedula_est, @odc_ciclo_est, @odc_carrera_est, 
                        @odc_unidad_acade, @odc_area, @odc_num_horas, @odc_director_carrera, @odc_nombre_per_aut, 
                        @odc_per_aut_cargo, @odc_autorizacion, 
                        @odc_nombre_tutor, @users_id) ";

            var result = await db.ExecuteAsync(sql, new
            {
                oficiodireccioncarrera.odc_fecha,
                oficiodireccioncarrera.odc_numero,
                oficiodireccioncarrera.odc_repre_legal,
                oficiodireccioncarrera.odc_nom_est,
                oficiodireccioncarrera.odc_cedula_est,
                oficiodireccioncarrera.odc_ciclo_est,
                oficiodireccioncarrera.odc_carrera_est,
                oficiodireccioncarrera.odc_unidad_acade,
                oficiodireccioncarrera.odc_area,
                oficiodireccioncarrera.odc_num_horas,
                oficiodireccioncarrera.odc_director_carrera,
                oficiodireccioncarrera.odc_nombre_per_aut,
                oficiodireccioncarrera.odc_per_aut_cargo,
                oficiodireccioncarrera.odc_autorizacion,
                oficiodireccioncarrera.odc_nombre_tutor,
                oficiodireccioncarrera.users_id,
                oficiodireccioncarrera.id
            });

            return result > 0;
        }

       
    }
}
