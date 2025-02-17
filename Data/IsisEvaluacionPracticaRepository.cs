using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisEvaluacionPracticaRepository
    {
        Task<IEnumerable<EvaluacionPractica>> GetAllEvaluacionPractica();
        Task<EvaluacionPractica> GetDetails(int id);
        Task<IEnumerable<EvaluacionPractica>> GetDetailsByUser(int users_id);
        Task<bool> InsertarEvaluacionPractica(EvaluacionPractica evaluacionPractica);
        Task<bool> ActualizarEvaluacionPractica(EvaluacionPractica evaluacionPractica);
        Task<bool> EliminarEvaluacionPractica(int id);

    }
}
