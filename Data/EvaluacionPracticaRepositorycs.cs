using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;
namespace sisdigitalizacion.Data
{
    public class EvaluacionPracticaRepositorycs : IsisEvaluacionPracticaRepository
    {
        private readonly MysqlConfiguracion _connectionString;
        public EvaluacionPracticaRepositorycs(MysqlConfiguracion connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        //empieza los metodos del crud
        public async Task<bool> ActualizarEvaluacionPractica(EvaluacionPractica evaluacionPractica)
        {
            var db = dbConnection();
            var sql = @"
            UPDATE evaluacionPractica SET 
                Empresa_institucion_proyecto = @Empresa_institucion_proyecto,
                Tipo_Practica = @Tipo_Practica,
                Representante_legal = @Representante_legal,
                Tutor_Empresarial = @Tutor_Empresarial,
                Area_Departamento = @Area_Departamento,
                Docente = @Docente,
                Estudiante = @Estudiante,
                Fecha_Inicio = @Fecha_Inicio,
                Fecha_Supervicion = @Fecha_Supervicion,
                Hora_Asistencia = @Hora_Asistencia,
                Hora_Supervision = @Hora_Supervision,
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
                Rcomendaciones = @Rcomendaciones,
                FechaRegistro = @FechaRegistro,
                Users_id = @Users_id
            WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                evaluacionPractica.Empresa_institucion_proyecto,
                evaluacionPractica.Tipo_Practica,
                evaluacionPractica.Representante_legal,
                evaluacionPractica.Tutor_Empresarial,
                evaluacionPractica.Area_Departamento,
                evaluacionPractica.Docente,
                evaluacionPractica.Estudiante,
                evaluacionPractica.Fecha_Inicio,
                evaluacionPractica.Fecha_Supervicion,
                evaluacionPractica.Hora_Asistencia,
                evaluacionPractica.Hora_Supervision,
                evaluacionPractica.RCAPregunta1,
                evaluacionPractica.RCAPregunta2,
                evaluacionPractica.RCAPregunta3,
                evaluacionPractica.RCAPregunta4,
                evaluacionPractica.RCAPregunta5,
                evaluacionPractica.Subtotal1,
                evaluacionPractica.ACPregunta1,
                evaluacionPractica.ACPregunta2,
                evaluacionPractica.ACPregunta3,
                evaluacionPractica.ACPregunta4,
                evaluacionPractica.ACPregunta5,
                evaluacionPractica.Subtotal2,
                evaluacionPractica.HDPregunta1,
                evaluacionPractica.HDPregunta2,
                evaluacionPractica.HDPregunta3,
                evaluacionPractica.HDPregunta4,
                evaluacionPractica.HDPregunta5,
                evaluacionPractica.Subtotal3,
                evaluacionPractica.AAPregunta1,
                evaluacionPractica.AAPregunta2,
                evaluacionPractica.AAPregunta3,
                evaluacionPractica.AAPregunta4,
                evaluacionPractica.AAPregunta5,
                evaluacionPractica.Subtotal4,
                evaluacionPractica.Total,
                evaluacionPractica.Observaciones,
                evaluacionPractica.Rcomendaciones,
                evaluacionPractica.FechaRegistro,
                evaluacionPractica.Users_id,
                evaluacionPractica.Id
            });

            return result > 0;
        }

        public async Task<bool> EliminarEvaluacionPractica(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM evaluacionPractica WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }



        public async Task<IEnumerable<EvaluacionPractica>> GetAllEvaluacionPractica()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM evaluacionPractica";
            return await db.QueryAsync<EvaluacionPractica>(sql, new { });

        }

        public async Task<EvaluacionPractica> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM evaluacionPractica WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<EvaluacionPractica>(sql, new { id = id });
        }

        public async Task<IEnumerable<EvaluacionPractica>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM evaluacionPractica WHERE users_id = @users_id";
            return await db.QueryAsync<EvaluacionPractica>(sql, new { users_id });
        }


        public async Task<bool> InsertarEvaluacionPractica(EvaluacionPractica evaluacionPractica)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO evaluacionPractica (
            Empresa_institucion_proyecto,
            Tipo_Practica,
            Representante_legal,
            Tutor_Empresarial,
            Area_Departamento,
            Docente,
            Estudiante,
            Fecha_Inicio,
            Fecha_Supervicion,
            Hora_Asistencia,
            Hora_Supervision,
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
            Rcomendaciones,
            FechaRegistro,
            Users_id
        ) 
        VALUES (
            @Empresa_institucion_proyecto,
            @Tipo_Practica,
            @Representante_legal,
            @Tutor_Empresarial,
            @Area_Departamento,
            @Docente,
            @Estudiante,
            @Fecha_Inicio,
            @Fecha_Supervicion,
            @Hora_Asistencia,
            @Hora_Supervision,
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
            @Rcomendaciones,
            @FechaRegistro,
            @Users_id)";

            var result = await db.ExecuteAsync(sql, new
            {
                evaluacionPractica.Empresa_institucion_proyecto,
                evaluacionPractica.Tipo_Practica,
                evaluacionPractica.Representante_legal,
                evaluacionPractica.Tutor_Empresarial,
                evaluacionPractica.Area_Departamento,
                evaluacionPractica.Docente,
                evaluacionPractica.Estudiante,
                evaluacionPractica.Fecha_Inicio,
                evaluacionPractica.Fecha_Supervicion,
                evaluacionPractica.Hora_Asistencia,
                evaluacionPractica.Hora_Supervision,
                evaluacionPractica.RCAPregunta1,
                evaluacionPractica.RCAPregunta2,
                evaluacionPractica.RCAPregunta3,
                evaluacionPractica.RCAPregunta4,
                evaluacionPractica.RCAPregunta5,
                evaluacionPractica.Subtotal1,
                evaluacionPractica.ACPregunta1,
                evaluacionPractica.ACPregunta2,
                evaluacionPractica.ACPregunta3,
                evaluacionPractica.ACPregunta4,
                evaluacionPractica.ACPregunta5,
                evaluacionPractica.Subtotal2,
                evaluacionPractica.HDPregunta1,
                evaluacionPractica.HDPregunta2,
                evaluacionPractica.HDPregunta3,
                evaluacionPractica.HDPregunta4,
                evaluacionPractica.HDPregunta5,
                evaluacionPractica.Subtotal3,
                evaluacionPractica.AAPregunta1,
                evaluacionPractica.AAPregunta2,
                evaluacionPractica.AAPregunta3,
                evaluacionPractica.AAPregunta4,
                evaluacionPractica.AAPregunta5,
                evaluacionPractica.Subtotal4,
                evaluacionPractica.Total,
                evaluacionPractica.Observaciones,
                evaluacionPractica.Rcomendaciones,
                evaluacionPractica.FechaRegistro,
                evaluacionPractica.Users_id
            });

            return result > 0;
        }



    }
}
