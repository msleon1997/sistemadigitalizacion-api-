using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisInformeTutorias
    {

        Task<IEnumerable<InformeTutorias>> GetAllInformeTutorias();
        Task<InformeTutorias> GetDetails(int id);
        Task<IEnumerable<InformeTutorias>> GetDetailsByUser(int users_id);
        Task<bool> InsertarInformeTutorias(InformeTutorias informeTutorias);
        Task<bool> ActualizarInformeTutorias(InformeTutorias informeTutorias);
        Task<bool> EliminarInformeTutorias(int id);
    }
}
