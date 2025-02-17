using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class EvaluacionFinalCertificadoRepository : IsisEvaluacionFinalCertificadoRepository
    {
        private readonly MysqlConfiguracion _connectionString;
        public EvaluacionFinalCertificadoRepository(MysqlConfiguracion connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //empieza los metodos del crud
        public async Task<bool> ActualizarEvaluacionFinalCertificado(EvaluacionFinalCertificado evaluacionFinalCertificado)
        {
            var db = dbConnection();
            var sql = @"
            UPDATE Evaluacion_Final_Cert SET 
                Nom_director_carrera = @Nom_director_carrera,
                Nom_est = @Nom_est,
                Num_cedula = @Num_cedula,
                Area_desarrollo = @Area_desarrollo,
                Duracion_horas = @Duracion_horas,
                Fecha_inicio = @Fecha_inicio,
                Fecha_fin = @Fecha_fin,
                Representante_empresa = @Representante_empresa,
                Est_nombre = @Est_nombre,
                Est_carrera = @Est_carrera,
                Est_ciclo = @Est_ciclo,
                RCAPregunta1 = @RCAPregunta1,
                RCAPregunta2 = @RCAPregunta2,
                RCAPregunta3 = @RCAPregunta3,
                RCAPregunta4 = @RCAPregunta4,
                RCAPregunta5 = @RCAPregunta5,
                Subtotal1 = @Subtotal1,
                ACPregunta1 = @ACPregunta1,
                ACPregunta2 = @ACPregunta2,
                ACPregunta3 = @ACPregunta3,
                ACPregunta4 = @ACPregunta4,
                ACPregunta5 = @ACPregunta5,
                Subtotal2 = @Subtotal2,
                HDPregunta1 = @HDPregunta1,
                HDPregunta2 = @HDPregunta2,
                HDPregunta3 = @HDPregunta3,
                HDPregunta4 = @HDPregunta4,
                HDPregunta5 = @HDPregunta5,
                Subtotal3 = @Subtotal3,
                AAPregunta1 = @AAPregunta1,
                AAPregunta2 = @AAPregunta2,
                AAPregunta3 = @AAPregunta3,
                AAPregunta4 = @AAPregunta4,
                AAPregunta5 = @AAPregunta5,
                Subtotal4 = @Subtotal4,
                Total = @Total,
                Observaciones = @Observaciones,
                Recomendaciones = @Recomendaciones,
                FechaRegistro = @FechaRegistro, 
                Nombre_Tutor_empresa = @Nombre_Tutor_empresa,
                Nombre_empresa = @Nombre_empresa,
                logo_empresa = @logo_empresa,
                users_id = @users_id
            WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                evaluacionFinalCertificado.Nom_director_carrera,
                evaluacionFinalCertificado.Nom_est,
                evaluacionFinalCertificado.Num_cedula,
                evaluacionFinalCertificado.Area_desarrollo,
                evaluacionFinalCertificado.Duracion_horas,
                evaluacionFinalCertificado.Fecha_inicio,
                evaluacionFinalCertificado.Fecha_fin,
                evaluacionFinalCertificado.Representante_empresa,
                evaluacionFinalCertificado.Est_nombre,
                evaluacionFinalCertificado.Est_carrera,
                evaluacionFinalCertificado.Est_ciclo,
                evaluacionFinalCertificado.RCAPregunta1,
                evaluacionFinalCertificado.RCAPregunta2,
                evaluacionFinalCertificado.RCAPregunta3,
                evaluacionFinalCertificado.RCAPregunta4,
                evaluacionFinalCertificado.RCAPregunta5,
                evaluacionFinalCertificado.Subtotal1,
                evaluacionFinalCertificado.ACPregunta1,
                evaluacionFinalCertificado.ACPregunta2,
                evaluacionFinalCertificado.ACPregunta3,
                evaluacionFinalCertificado.ACPregunta4,
                evaluacionFinalCertificado.ACPregunta5,
                evaluacionFinalCertificado.Subtotal2,
                evaluacionFinalCertificado.HDPregunta1,
                evaluacionFinalCertificado.HDPregunta2,
                evaluacionFinalCertificado.HDPregunta3,
                evaluacionFinalCertificado.HDPregunta4,
                evaluacionFinalCertificado.HDPregunta5,
                evaluacionFinalCertificado.Subtotal3,
                evaluacionFinalCertificado.AAPregunta1,
                evaluacionFinalCertificado.AAPregunta2,
                evaluacionFinalCertificado.AAPregunta3,
                evaluacionFinalCertificado.AAPregunta4,
                evaluacionFinalCertificado.AAPregunta5,
                evaluacionFinalCertificado.Subtotal4,
                evaluacionFinalCertificado.Total,
                evaluacionFinalCertificado.Observaciones,
                evaluacionFinalCertificado.Recomendaciones,
                evaluacionFinalCertificado.FechaRegistro,
                evaluacionFinalCertificado.Nombre_Tutor_empresa,
                evaluacionFinalCertificado.Nombre_empresa,
                evaluacionFinalCertificado.logo_empresa,
                evaluacionFinalCertificado.users_id,
                evaluacionFinalCertificado.Id
            });

            return result > 0;
        }


        public async Task<bool> EliminarEvaluacionFinalCertificado(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM Evaluacion_Final_Cert WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public async Task<IEnumerable<EvaluacionFinalCertificado>> GetAllEvaluacionFinalCertificado()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM Evaluacion_Final_Cert";
            return await db.QueryAsync<EvaluacionFinalCertificado>(sql, new { });

        }

        public async Task<EvaluacionFinalCertificado> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM Evaluacion_Final_Cert WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<EvaluacionFinalCertificado>(sql, new { id = id });
        }


        public async Task<IEnumerable<EvaluacionFinalCertificado>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM Evaluacion_Final_Cert WHERE users_id = @users_id";
            return await db.QueryAsync<EvaluacionFinalCertificado>(sql, new { users_id });
        }


        public async Task<bool> InsertarEvaluacionFinalCertificado(EvaluacionFinalCertificado evaluacionFinalCertificado)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Evaluacion_Final_Cert (
            Nom_director_carrera,
            Nom_est,
            Num_cedula,
            Area_desarrollo,
            Duracion_horas,
            Fecha_inicio,
            Fecha_fin,
            Representante_empresa,
            Est_nombre,
            Est_carrera,
            Est_ciclo,
            RCAPregunta1,
            RCAPregunta2,
            RCAPregunta3,
            RCAPregunta4,
            RCAPregunta5,
            Subtotal1,
            ACPregunta1,
            ACPregunta2,
            ACPregunta3,
            ACPregunta4,
            ACPregunta5,
            Subtotal2,
            HDPregunta1,
            HDPregunta2,
            HDPregunta3,
            HDPregunta4,
            HDPregunta5,
            Subtotal3,
            AAPregunta1,
            AAPregunta2,
            AAPregunta3,
            AAPregunta4,
            AAPregunta5,
            Subtotal4,
            Total,
            Observaciones,
            Recomendaciones,
            FechaRegistro,
            Nombre_Tutor_empresa,
            Nombre_empresa,
            logo_empresa,
            users_id
        ) 
        VALUES (
            @Nom_director_carrera,
            @Nom_est,
            @Num_cedula,
            @Area_desarrollo,
            @Duracion_horas,
            @Fecha_inicio,
            @Fecha_fin,
            @Representante_empresa,
            @Est_nombre,
            @Est_carrera,
            @Est_ciclo,
            @RCAPregunta1,
            @RCAPregunta2,
            @RCAPregunta3,
            @RCAPregunta4,
            @RCAPregunta5,
            @Subtotal1,
            @ACPregunta1,
            @ACPregunta2,
            @ACPregunta3,
            @ACPregunta4,
            @ACPregunta5,
            @Subtotal2,
            @HDPregunta1,
            @HDPregunta2,
            @HDPregunta3,
            @HDPregunta4,
            @HDPregunta5,
            @Subtotal3,
            @AAPregunta1,
            @AAPregunta2,
            @AAPregunta3,
            @AAPregunta4,
            @AAPregunta5,
            @Subtotal4,
            @Total,
            @Observaciones,
            @Recomendaciones,
            @FechaRegistro,
            @Nombre_Tutor_empresa,
            @Nombre_empresa,
            @logo_empresa,
            @users_id)";

            var result = await db.ExecuteAsync(sql, new
            {
                evaluacionFinalCertificado.Nom_director_carrera,
                evaluacionFinalCertificado.Nom_est,
                evaluacionFinalCertificado.Num_cedula,
                evaluacionFinalCertificado.Area_desarrollo,
                evaluacionFinalCertificado.Duracion_horas,
                evaluacionFinalCertificado.Fecha_inicio,
                evaluacionFinalCertificado.Fecha_fin,
                evaluacionFinalCertificado.Representante_empresa,
                evaluacionFinalCertificado.Est_nombre,
                evaluacionFinalCertificado.Est_carrera,
                evaluacionFinalCertificado.Est_ciclo,
                evaluacionFinalCertificado.RCAPregunta1,
                evaluacionFinalCertificado.RCAPregunta2,
                evaluacionFinalCertificado.RCAPregunta3,
                evaluacionFinalCertificado.RCAPregunta4,
                evaluacionFinalCertificado.RCAPregunta5,
                evaluacionFinalCertificado.Subtotal1,
                evaluacionFinalCertificado.ACPregunta1,
                evaluacionFinalCertificado.ACPregunta2,
                evaluacionFinalCertificado.ACPregunta3,
                evaluacionFinalCertificado.ACPregunta4,
                evaluacionFinalCertificado.ACPregunta5,
                evaluacionFinalCertificado.Subtotal2,
                evaluacionFinalCertificado.HDPregunta1,
                evaluacionFinalCertificado.HDPregunta2,
                evaluacionFinalCertificado.HDPregunta3,
                evaluacionFinalCertificado.HDPregunta4,
                evaluacionFinalCertificado.HDPregunta5,
                evaluacionFinalCertificado.Subtotal3,
                evaluacionFinalCertificado.AAPregunta1,
                evaluacionFinalCertificado.AAPregunta2,
                evaluacionFinalCertificado.AAPregunta3,
                evaluacionFinalCertificado.AAPregunta4,
                evaluacionFinalCertificado.AAPregunta5,
                evaluacionFinalCertificado.Subtotal4,
                evaluacionFinalCertificado.Total,
                evaluacionFinalCertificado.Observaciones,
                evaluacionFinalCertificado.Recomendaciones,
                evaluacionFinalCertificado.FechaRegistro,
                evaluacionFinalCertificado.Nombre_Tutor_empresa,
                evaluacionFinalCertificado.Nombre_empresa,
                evaluacionFinalCertificado.logo_empresa,
                evaluacionFinalCertificado.users_id
            });

            return result > 0;
        }



    }
}
