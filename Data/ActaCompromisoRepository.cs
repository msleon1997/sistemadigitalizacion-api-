using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class ActaCompromisoRepository : IsisactaCompromiso
    {
        private readonly MysqlConfiguracion _connectionString;

        public ActaCompromisoRepository(MysqlConfiguracion connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        //empieza los metodos del crud
        public async Task<bool> ActualizarActaCompromiso(ActaCompromiso actaCompromiso)
        {
            var db = dbConnection();
            var sql = @"
        UPDATE acta_compromiso SET 
              Acta_NombresEstudiante = @Acta_NombresEstudiante,
              Acta_Carrera = @Acta_Carrera,
              Acta_UnidadAcademica = @Acta_UnidadAcademica,
              Acta_NombreEmpresa = @Acta_NombreEmpresa,
              users_id = @users_id
              
        WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                actaCompromiso.Acta_NombresEstudiante,
                actaCompromiso.Acta_Carrera,
                actaCompromiso.Acta_UnidadAcademica,
                actaCompromiso.Acta_NombreEmpresa,
                actaCompromiso.users_id,
                actaCompromiso.id
            });

            return result > 0;
        }


        public async Task<bool> EliminarActaCompromiso(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM acta_compromiso WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }



        public async Task<IEnumerable<ActaCompromiso>> GetAllActaCompromiso()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM acta_compromiso";
            return await db.QueryAsync<ActaCompromiso>(sql, new { });

        }

        public async Task<ActaCompromiso> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM acta_compromiso WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<ActaCompromiso>(sql, new { id = id });
        }

        public async Task<IEnumerable<ActaCompromiso>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM acta_compromiso WHERE users_id = @users_id";
            return await db.QueryAsync<ActaCompromiso>(sql, new { users_id });
        }


        public async Task<bool> InsertarActaCompromiso(ActaCompromiso actaCompromiso)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO acta_compromiso (
              
              Acta_NombresEstudiante,
              Acta_Carrera,
              Acta_UnidadAcademica,
              Acta_NombreEmpresa,
              users_id
             ) 
               VALUES 
                (
              @Acta_NombresEstudiante,
              @Acta_Carrera,
              @Acta_UnidadAcademica,
              @Acta_NombreEmpresa,
              @users_id)";

            var result = await db.ExecuteAsync(sql, new
            {
                actaCompromiso.Acta_NombresEstudiante,
                actaCompromiso.Acta_Carrera,
                actaCompromiso.Acta_UnidadAcademica,
                actaCompromiso.Acta_NombreEmpresa,
                actaCompromiso.users_id,
                actaCompromiso.id
            });

            return result > 0;
        }








    }
}
