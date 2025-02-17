using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisInformeFinal
    {


        Task<IEnumerable<InformeFinal>> GetAllInformeFinal();
        Task<InformeFinal> GetDetails(int id);
        Task<IEnumerable<InformeFinal>> GetDetailsByUser(int users_id);
        Task<bool> InsertarInformeFinal(InformeFinal informeFinal);
        Task<bool> ActualizarInformeFinal(InformeFinal informeFinal);
        Task<bool> EliminarInformeFinal(int id);


    }
}
