using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisactividadesPracticas
    {
        Task<IEnumerable<ActividadesPracticas>> GetAllActividadesPracticas();
        Task<ActividadesPracticas> GetDetails(int id);
        Task<IEnumerable<ActividadesPracticas>> GetDetailsByUser(int users_id);
        Task<bool> InsertarActividadesPracticas(ActividadesPracticas actividadesPracticas);
        Task<bool> ActualizarActividadesPracticas(ActividadesPracticas actividadesPracticas);
        Task<bool> EliminarActividadesPracticas(int id);
    }
}
