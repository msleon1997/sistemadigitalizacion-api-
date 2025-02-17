using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class InformeActividadesPracticasRepository : IsisInformeActividadesPracticas{

        private readonly MysqlConfiguracion _connectionString;
        public InformeActividadesPracticasRepository(MysqlConfiguracion connectionString)
        {
            _connectionString = connectionString;

        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        public async Task<IEnumerable<InformeActividadesPracticas>> GetAllInformeActividadesPracticas()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM vista_practicas_completa";
            return await db.QueryAsync<InformeActividadesPracticas>(sql, new { });

        }

        public async Task<InformeActividadesPracticas> GetDetails(int id)
        {
           
                var db = dbConnection();
                var sql = @" SELECT * FROM vista_practicas_completa WHERE id_practica = @id";
                return await db.QueryFirstOrDefaultAsync<InformeActividadesPracticas>(sql, new { id });
            
        }


        public async Task<IEnumerable<InformeActividadesPracticas>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM vista_practicas_completa WHERE usuario_id = @users_id";
            return await db.QueryAsync<InformeActividadesPracticas>(sql, new { users_id });
        }


        

    }

}
