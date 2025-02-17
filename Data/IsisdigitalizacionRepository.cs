using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisdigitalizacionRepository
    {
        Task<IEnumerable<Planificacion>> GetAllPlanificaciones();
        Task<Planificacion> GetDetails(int id);
        Task<IEnumerable<Planificacion>> GetDetailsByUser(int users_id);
        Task<IEnumerable<Planificacion>> GetDetailsWithMatriculacion(int id);
        Task<bool> InsertarPlanificacion(Planificacion planificacion);
        Task<bool> ActualizarPlanificacion(Planificacion planificacion);
        Task<bool> EliminarPlanificacion(int id);


    }
}
