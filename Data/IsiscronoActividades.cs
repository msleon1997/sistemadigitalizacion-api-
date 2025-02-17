using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsiscronoActividades
    {
        Task<IEnumerable<CronoActividades>> GetAllCronoActividades();
        Task<CronoActividades> GetDetails(int id);
        Task<IEnumerable<CronoActividades>> GetDetailsByUser(int users_id);
        Task<bool> InsertarCronoActividades(CronoActividades cronoActividades);
        Task<bool> ActualizaCronoActividades(CronoActividades cronoActividades);
        Task<bool> EliminarCronoActividades(int id);
    }
}
