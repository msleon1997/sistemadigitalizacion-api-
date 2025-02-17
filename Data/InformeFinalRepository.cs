using Dapper;
using MySqlConnector;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public class InformeFinalRepository : IsisInformeFinal {


        private readonly MysqlConfiguracion _connectionString;
        public InformeFinalRepository(MysqlConfiguracion connectionString)
        {
            _connectionString = connectionString;

        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        //empieza los metodos del crud
        public async Task<bool> ActualizarInformeFinal(InformeFinal informeFinal)
        {
            var db = dbConnection();
            var sql = @"
                UPDATE informe_final SET 
                    Empresa_Institucion_Proyecto = @Empresa_Institucion_Proyecto,
                    Tutor_externo = @Tutor_externo,
                    Estudiante_grupo = @Estudiante_grupo,
                    Docente_tutor = @Docente_tutor,
                    Periodo_practicas = @Periodo_practicas,
                    Introduccion = @Introduccion,
                    Obj_general = @Obj_general,
                    Obj_especifico = @Obj_especifico,
                    Justificacion = @Justificacion,
                    Antecedentes = @Antecedentes,
                    Mision_inst = @Mision_inst,
                    Vision_inst = @Vision_inst,
                    Obj_inst = @Obj_inst,
                    Valores_inst = @Valores_inst,
                    Bene_directos = @Bene_directos,
                    Bene_indirectos = @Bene_indirectos,
                    RA_asignatura = @RA_asignatura,
                    RA_resultado_aprendizaje = @RA_resultado_aprendizaje,
                    RA_perfil_egreso = @RA_perfil_egreso,
                    Evaluacion_impacto = @Evaluacion_impacto,
                    Detalle_actividades = @Detalle_actividades,
                    AUTOEVL_estudiante = @AUTOEVL_estudiante,
                    AUTOEVL_pregunta1 = @AUTOEVL_pregunta1,
                    AUTOEVL_pregunta2 = @AUTOEVL_pregunta2,
                    AUTOEVL_pregunta3 = @AUTOEVL_pregunta3,
                    AUTOEVL_pregunta4 = @AUTOEVL_pregunta4,
                    AUTOEVL_pregunta5 = @AUTOEVL_pregunta5,
                    AUTOEVL_pregunta6 = @AUTOEVL_pregunta6,
                    AUTOEVL_pregunta7 = @AUTOEVL_pregunta7,
                    AUTOEVL_pregunta8 = @AUTOEVL_pregunta8,
                    AUTOEVL_pregunta9 = @AUTOEVL_pregunta9,
                    AUTOEVL_pregunta10 = @AUTOEVL_pregunta10,
                    AUTOEVL_pregunta11 = @AUTOEVL_pregunta11,
                    AUTOEVL_pregunta12 = @AUTOEVL_pregunta12,
                    AUTOEVL_pregunta13 = @AUTOEVL_pregunta13,
                    AUTOEVL_pregunta14 = @AUTOEVL_pregunta14,
                    AUTOEVL_pregunta15 = @AUTOEVL_pregunta15,
                    AUTOEVL_pregunta16 = @AUTOEVL_pregunta16,
                    AUTOEVL_pregunta17 = @AUTOEVL_pregunta17,
                    AUTOEVL_pregunta18 = @AUTOEVL_pregunta18,
                    Conclusiones = @Conclusiones,
                    Recomendaciones = @Recomendaciones,
                    Biografia = @Biografia,
                    Anexos = @Anexos,
                    Aprobaciones = @Aprobaciones,
                    users_id = @Users_id,
                    planificacion_id = @Planificacion_id
                WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new
            {
                informeFinal.Empresa_Institucion_Proyecto,
                informeFinal.Tutor_externo,
                informeFinal.Estudiante_grupo,
                informeFinal.Docente_tutor,
                informeFinal.Periodo_practicas,
                informeFinal.Introduccion,
                informeFinal.Obj_general,
                informeFinal.Obj_especifico,
                informeFinal.Justificacion,
                informeFinal.Antecedentes,
                informeFinal.Mision_inst,
                informeFinal.Vision_inst,
                informeFinal.Obj_inst,
                informeFinal.Valores_inst,
                informeFinal.Bene_directos,
                informeFinal.Bene_indirectos,
                informeFinal.RA_asignatura,
                informeFinal.RA_resultado_aprendizaje,
                informeFinal.RA_perfil_egreso,
                informeFinal.Evaluacion_impacto,
                informeFinal.Detalle_actividades,
                informeFinal.AUTOEVL_estudiante,
                informeFinal.AUTOEVL_pregunta1,
                informeFinal.AUTOEVL_pregunta2,
                informeFinal.AUTOEVL_pregunta3,
                informeFinal.AUTOEVL_pregunta4,
                informeFinal.AUTOEVL_pregunta5,
                informeFinal.AUTOEVL_pregunta6,
                informeFinal.AUTOEVL_pregunta7,
                informeFinal.AUTOEVL_pregunta8,
                informeFinal.AUTOEVL_pregunta9,
                informeFinal.AUTOEVL_pregunta10,
                informeFinal.AUTOEVL_pregunta11,
                informeFinal.AUTOEVL_pregunta12,
                informeFinal.AUTOEVL_pregunta13,
                informeFinal.AUTOEVL_pregunta14,
                informeFinal.AUTOEVL_pregunta15,
                informeFinal.AUTOEVL_pregunta16,
                informeFinal.AUTOEVL_pregunta17,
                informeFinal.AUTOEVL_pregunta18,
                informeFinal.Conclusiones,
                informeFinal.Recomendaciones,
                informeFinal.Biografia,
                informeFinal.Anexos,
                informeFinal.Aprobaciones,
                informeFinal.Users_id,
                informeFinal.Planificacion_id,
                informeFinal.Id
            });

            return result > 0;
        }


        public async Task<bool> EliminarInformeFinal(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM informe_final WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public async Task<IEnumerable<InformeFinal>> GetAllInformeFinal()
        {

            var db = dbConnection();
            var sql = @" SELECT * FROM informe_final";
            return await db.QueryAsync<InformeFinal>(sql, new { });

        }

        public async Task<InformeFinal> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM informe_final WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<InformeFinal>(sql, new { id = id });
        }

        public async Task<IEnumerable<InformeFinal>> GetDetailsByUser(int users_id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM informe_final WHERE users_id = @users_id";
            return await db.QueryAsync<InformeFinal>(sql, new { users_id });
        }


        public async Task<bool> InsertarInformeFinal(InformeFinal informeFinal)
        {
            var db = dbConnection();

            var sql = @"
                INSERT INTO informe_final (
                    Empresa_Institucion_Proyecto,
                    Tutor_externo,
                    Estudiante_grupo,
                    Docente_tutor,
                    Periodo_practicas,
                    Introduccion,
                    Obj_general,
                    Obj_especifico,
                    Justificacion,
                    Antecedentes,
                    Mision_inst,
                    Vision_inst,
                    Obj_inst,
                    Valores_inst,
                    Bene_directos,
                    Bene_indirectos,
                    RA_asignatura,
                    RA_resultado_aprendizaje,
                    RA_perfil_egreso,
                    Evaluacion_impacto,
                    Detalle_actividades,
                    AUTOEVL_estudiante,
                    AUTOEVL_pregunta1,
                    AUTOEVL_pregunta2,
                    AUTOEVL_pregunta3,
                    AUTOEVL_pregunta4,
                    AUTOEVL_pregunta5,
                    AUTOEVL_pregunta6,
                    AUTOEVL_pregunta7,
                    AUTOEVL_pregunta8,
                    AUTOEVL_pregunta9,
                    AUTOEVL_pregunta10,
                    AUTOEVL_pregunta11,
                    AUTOEVL_pregunta12,
                    AUTOEVL_pregunta13,
                    AUTOEVL_pregunta14,
                    AUTOEVL_pregunta15,
                    AUTOEVL_pregunta16,
                    AUTOEVL_pregunta17,
                    AUTOEVL_pregunta18,
                    Conclusiones,
                    Recomendaciones,
                    Biografia,
                    Anexos,
                    Aprobaciones,
                    users_id,
                    planificacion_id

                ) 
                VALUES (
                    @Empresa_Institucion_Proyecto,
                    @Tutor_externo,
                    @Estudiante_grupo,
                    @Docente_tutor,
                    @Periodo_practicas,
                    @Introduccion,
                    @Obj_general,
                    @Obj_especifico,
                    @Justificacion,
                    @Antecedentes,
                    @Mision_inst,
                    @Vision_inst,
                    @Obj_inst,
                    @Valores_inst,
                    @Bene_directos,
                    @Bene_indirectos,
                    @RA_asignatura,
                    @RA_resultado_aprendizaje,
                    @RA_perfil_egreso,
                    @Evaluacion_impacto,
                    @Detalle_actividades,
                    @AUTOEVL_estudiante,
                    @AUTOEVL_pregunta1,
                    @AUTOEVL_pregunta2,
                    @AUTOEVL_pregunta3,
                    @AUTOEVL_pregunta4,
                    @AUTOEVL_pregunta5,
                    @AUTOEVL_pregunta6,
                    @AUTOEVL_pregunta7,
                    @AUTOEVL_pregunta8,
                    @AUTOEVL_pregunta9,
                    @AUTOEVL_pregunta10,
                    @AUTOEVL_pregunta11,
                    @AUTOEVL_pregunta12,
                    @AUTOEVL_pregunta13,
                    @AUTOEVL_pregunta14,
                    @AUTOEVL_pregunta15,
                    @AUTOEVL_pregunta16,
                    @AUTOEVL_pregunta17,
                    @AUTOEVL_pregunta18,
                    @Conclusiones,
                    @Recomendaciones,
                    @Biografia,
                    @Anexos,
                    @Aprobaciones,
                    @Users_id,
                    @Planificacion_id

                )";

            var result = await db.ExecuteAsync(sql, new
            {
                informeFinal.Empresa_Institucion_Proyecto,
                informeFinal.Tutor_externo,
                informeFinal.Estudiante_grupo,
                informeFinal.Docente_tutor,
                informeFinal.Periodo_practicas,
                informeFinal.Introduccion,
                informeFinal.Obj_general,
                informeFinal.Obj_especifico,
                informeFinal.Justificacion,
                informeFinal.Antecedentes,
                informeFinal.Mision_inst,
                informeFinal.Vision_inst,
                informeFinal.Obj_inst,
                informeFinal.Valores_inst,
                informeFinal.Bene_directos,
                informeFinal.Bene_indirectos,
                informeFinal.RA_asignatura,
                informeFinal.RA_resultado_aprendizaje,
                informeFinal.RA_perfil_egreso,
                informeFinal.Evaluacion_impacto,
                informeFinal.Detalle_actividades,
                informeFinal.AUTOEVL_estudiante,
                informeFinal.AUTOEVL_pregunta1,
                informeFinal.AUTOEVL_pregunta2,
                informeFinal.AUTOEVL_pregunta3,
                informeFinal.AUTOEVL_pregunta4,
                informeFinal.AUTOEVL_pregunta5,
                informeFinal.AUTOEVL_pregunta6,
                informeFinal.AUTOEVL_pregunta7,
                informeFinal.AUTOEVL_pregunta8,
                informeFinal.AUTOEVL_pregunta9,
                informeFinal.AUTOEVL_pregunta10,
                informeFinal.AUTOEVL_pregunta11,
                informeFinal.AUTOEVL_pregunta12,
                informeFinal.AUTOEVL_pregunta13,
                informeFinal.AUTOEVL_pregunta14,
                informeFinal.AUTOEVL_pregunta15,
                informeFinal.AUTOEVL_pregunta16,
                informeFinal.AUTOEVL_pregunta17,
                informeFinal.AUTOEVL_pregunta18,
                informeFinal.Conclusiones,
                informeFinal.Recomendaciones,
                informeFinal.Biografia,
                informeFinal.Anexos,
                informeFinal.Aprobaciones,
                informeFinal.Users_id,
                informeFinal.Planificacion_id
            });

            return result > 0;
        }





    }

}

