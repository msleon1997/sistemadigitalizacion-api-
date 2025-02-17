using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class InformeTutorialRepository : IsisInformeTutorias
    {

        private readonly MysqlConfiguracion _connectionString;
        public InformeTutorialRepository(MysqlConfiguracion connectionString)
        {
            _connectionString = connectionString;

        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        //empieza los metodos del crud
        public async Task<bool> ActualizarInformeTutorias(InformeTutorias informeTutorias)
        {

                var db = dbConnection();
                var sql = @"
                UPDATE informe_tutorias SET 
                    Docente_tutor = @Docente_tutor,
                    Docente_tutor_est = @Docente_tutor_est,
                    Empresa_proyecto = @Empresa_proyecto,
                    Periodo_practicas = @Periodo_practicas,
                    Carrera_est = @Carrera_est,
                    Area_desarrollo = @Area_desarrollo,
                    Director_carrera = @Director_carrera,
                    Fecha_inicio = @Fecha_inicio,
                    Fecha_fin = @Fecha_fin,
                    Est_cedula = @Est_cedula,
                    Est_apellidos = @Est_apellidos,
                    Est_nombres = @Est_nombres,
                    Est_ciclo = @Est_ciclo,
                    Introduccion = @Introduccion,
                    Descripcion_actividades = @Descripcion_actividades,
                    Conclusion = @Conclusion,
                    Observaciones = @Observaciones,
                    Anexos = @Anexos,
                    Unidad_academica = @Unidad_academica,
                    Componente_tematico = @Componente_tematico,
                    Dia = @Dia,
                    Mes = @Mes,
                    Ano = @Ano,
                    Tema_consulta = @Tema_consulta,
                    RT_Ciclo = @RT_Ciclo,
                    Modalidad = @Modalidad,
                    RT_Estudiante = @RT_Estudiante,
                    RT_Cedula_est = @RT_Cedula_est,
                    Responsable_docente_tutor = @Responsable_docente_tutor,
                    Responsable_ptt = @Responsable_ptt,
                    Responsable_dic_carrera = @Responsable_dic_carrera,
                    Accion_1 = @Accion_1,
                    Accion_2 = @Accion_2,
                    Accion_3 = @Accion_3,
                    Fecha_aprovacion1 = @Fecha_aprovacion1,
                    Fecha_aprovacion2 = @Fecha_aprovacion2,
                    Fecha_aprovacion3 = @Fecha_aprovacion3,
                    Firma_1 = @Firma_1,
                    Firma_2 = @Firma_2,
                    Firma_3 = @Firma_3,
                    users_id = @users_id,
                    planificacion_id = @planificacion_id
                WHERE id = @id";

                var result = await db.ExecuteAsync(sql, new
                {
                    informeTutorias.Docente_tutor,
                    informeTutorias.Docente_tutor_est,
                    informeTutorias.Empresa_proyecto,
                    informeTutorias.Periodo_practicas,
                    informeTutorias.Carrera_est,
                    informeTutorias.Area_desarrollo,
                    informeTutorias.Director_carrera,
                    informeTutorias.Fecha_inicio,
                    informeTutorias.Fecha_fin,
                    informeTutorias.Est_cedula,
                    informeTutorias.Est_apellidos,
                    informeTutorias.Est_nombres,
                    informeTutorias.Est_ciclo,
                    informeTutorias.Introduccion,
                    informeTutorias.Descripcion_actividades,
                    informeTutorias.Conclusion,
                    informeTutorias.Observaciones,
                    informeTutorias.Anexos,
                    informeTutorias.Unidad_academica,
                    informeTutorias.Componente_tematico,
                    informeTutorias.Dia,
                    informeTutorias.Mes,
                    informeTutorias.Ano,
                    informeTutorias.Tema_consulta,
                    informeTutorias.RT_Ciclo,
                    informeTutorias.Modalidad,
                    informeTutorias.RT_Estudiante,
                    informeTutorias.RT_Cedula_est,
                    informeTutorias.Responsable_docente_tutor,
                    informeTutorias.Responsable_ptt,
                    informeTutorias.Responsable_dic_carrera,
                    informeTutorias.Accion_1,
                    informeTutorias.Accion_2,
                    informeTutorias.Accion_3,
                    informeTutorias.Fecha_aprovacion1,
                    informeTutorias.Fecha_aprovacion2,
                    informeTutorias.Fecha_aprovacion3,
                    informeTutorias.Firma_1,
                    informeTutorias.Firma_2,
                    informeTutorias.Firma_3,
                    informeTutorias.users_id,
                    informeTutorias.planificacion_id,
                    informeTutorias.id
                });

                return result > 0;
            }
           
        

            public async Task<bool> EliminarInformeTutorias(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM informe_tutorias WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public async Task<IEnumerable<InformeTutorias>> GetAllInformeTutorias()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM informe_tutorias";
            return await db.QueryAsync<InformeTutorias>(sql, new { });

        }

        public async Task<InformeTutorias> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM informe_tutorias WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<InformeTutorias>(sql, new { id = id });
        }

        public async Task<IEnumerable<InformeTutorias>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM informe_tutorias WHERE users_id = @users_id";
            return await db.QueryAsync<InformeTutorias>(sql, new { users_id });
        }

        public async Task<bool> InsertarInformeTutorias(InformeTutorias informeTutorias)
        {

          
                var db = dbConnection();

                var sql = @"
                INSERT INTO informe_tutorias (
                    Docente_tutor,
                    Docente_tutor_est,
                    Empresa_proyecto,
                    Periodo_practicas,
                    Carrera_est,
                    Area_desarrollo,
                    Director_carrera,
                    Fecha_inicio,
                    Fecha_fin,
                    Est_cedula,
                    Est_apellidos,
                    Est_nombres,
                    Est_ciclo,
                    Introduccion,
                    Descripcion_actividades,
                    Conclusion,
                    Observaciones,
                    Anexos,
                    Unidad_academica,
                    Componente_tematico,
                    Dia,
                    Mes,
                    Ano,
                    Tema_consulta,
                    RT_Ciclo,
                    Modalidad,
                    RT_Estudiante,
                    RT_Cedula_est,
                    Responsable_docente_tutor,
                    Responsable_ptt,
                    Responsable_dic_carrera,
                    Accion_1,
                    Accion_2,
                    Accion_3,
                    Fecha_aprovacion1,
                    Fecha_aprovacion2,
                    Fecha_aprovacion3,
                    Firma_1,
                    Firma_2,
                    Firma_3,
                    users_id,
                    planificacion_id
                ) 
                VALUES (
                    @Docente_tutor,
                    @Docente_tutor_est,
                    @Empresa_proyecto,
                    @Periodo_practicas,
                    @Carrera_est,
                    @Area_desarrollo,
                    @Director_carrera,
                    @Fecha_inicio,
                    @Fecha_fin,
                    @Est_cedula,
                    @Est_apellidos,
                    @Est_nombres,
                    @Est_ciclo,
                    @Introduccion,
                    @Descripcion_actividades,
                    @Conclusion,
                    @Observaciones,
                    @Anexos,
                    @Unidad_academica,
                    @Componente_tematico,
                    @Dia,
                    @Mes,
                    @Ano,
                    @Tema_consulta,
                    @RT_Ciclo,
                    @Modalidad,
                    @RT_Estudiante,
                    @RT_Cedula_est,
                    @Responsable_docente_tutor,
                    @Responsable_ptt,
                    @Responsable_dic_carrera,
                    @Accion_1,
                    @Accion_2,
                    @Accion_3,
                    @Fecha_aprovacion1,
                    @Fecha_aprovacion2,
                    @Fecha_aprovacion3,
                    @Firma_1,
                    @Firma_2,
                    @Firma_3,
                    @users_id,
                    @planificacion_id
                )";

                var result = await db.ExecuteAsync(sql, new
                {
                    informeTutorias.Docente_tutor,
                    informeTutorias.Docente_tutor_est,
                    informeTutorias.Empresa_proyecto,
                    informeTutorias.Periodo_practicas,
                    informeTutorias.Carrera_est,
                    informeTutorias.Area_desarrollo,
                    informeTutorias.Director_carrera,
                    informeTutorias.Fecha_inicio,
                    informeTutorias.Fecha_fin,
                    informeTutorias.Est_cedula,
                    informeTutorias.Est_apellidos,
                    informeTutorias.Est_nombres,
                    informeTutorias.Est_ciclo,
                    informeTutorias.Introduccion,
                    informeTutorias.Descripcion_actividades,
                    informeTutorias.Conclusion,
                    informeTutorias.Observaciones,
                    informeTutorias.Anexos,
                    informeTutorias.Unidad_academica,
                    informeTutorias.Componente_tematico,
                    informeTutorias.Dia,
                    informeTutorias.Mes,
                    informeTutorias.Ano,
                    informeTutorias.Tema_consulta,
                    informeTutorias.RT_Ciclo,
                    informeTutorias.Modalidad,
                    informeTutorias.RT_Estudiante,
                    informeTutorias.RT_Cedula_est,
                    informeTutorias.Responsable_docente_tutor,
                    informeTutorias.Responsable_ptt,
                    informeTutorias.Responsable_dic_carrera,
                    informeTutorias.Accion_1,
                    informeTutorias.Accion_2,
                    informeTutorias.Accion_3,
                    informeTutorias.Fecha_aprovacion1,
                    informeTutorias.Fecha_aprovacion2,
                    informeTutorias.Fecha_aprovacion3,
                    informeTutorias.Firma_1,
                    informeTutorias.Firma_2,
                    informeTutorias.Firma_3,
                    informeTutorias.users_id,
                    informeTutorias.planificacion_id,
                    informeTutorias.id
                });

                return result > 0;
            }
           
        



        }
}
