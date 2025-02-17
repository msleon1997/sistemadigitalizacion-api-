using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisEvaluacionFinalCertificadoRepository
    {
        Task<IEnumerable<EvaluacionFinalCertificado>> GetAllEvaluacionFinalCertificado();
        Task<EvaluacionFinalCertificado> GetDetails(int id);
        Task<IEnumerable<EvaluacionFinalCertificado>> GetDetailsByUser(int users_id);
        Task<bool> InsertarEvaluacionFinalCertificado(EvaluacionFinalCertificado evaluacionFinalCertificado);
        Task<bool> ActualizarEvaluacionFinalCertificado(EvaluacionFinalCertificado evaluacionFinalCertificado);
        Task<bool> EliminarEvaluacionFinalCertificado(int id);
    }
}
