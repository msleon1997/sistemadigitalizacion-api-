using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisactaCompromiso
    {
        Task<IEnumerable<ActaCompromiso>> GetAllActaCompromiso();
        Task<ActaCompromiso> GetDetails(int id);
        Task<IEnumerable<ActaCompromiso>> GetDetailsByUser(int users_id);
        Task<bool> InsertarActaCompromiso(ActaCompromiso actaCompromiso);
        Task<bool> ActualizarActaCompromiso(ActaCompromiso actaCompromiso);
        Task<bool> EliminarActaCompromiso(int id);
    }
}
