using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisMatriculacionRepository
    {

        Task<bool> ActualizarMatriculacion(Matriculacion matriculacion);
        Task<bool> EliminarMatriculacion(int id);
        Task<IEnumerable<Matriculacion>> GetAllMatriculacion();
        Task<Matriculacion> GetDetails(int id);
        Task<IEnumerable<Matriculacion>> GetDetailsByUser(int users_id);
        Task<bool> InsertarMatriculacion(Matriculacion matriculacion);
    }
}
