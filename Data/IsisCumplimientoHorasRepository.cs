using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisCumplimientoHorasRepository
    {

        Task<IEnumerable<CumplimientoHoras>> GetAllCumplimientoHoras();
        Task<CumplimientoHoras> GetDetails(int id);
        Task<IEnumerable<CumplimientoHoras>> GetDetailsByUser(int users_id);
        Task<bool> InsertarCumplimientoHoras(CumplimientoHoras cumplimientoHoras);
        Task<bool> ActualizarCumplimientoHoras(CumplimientoHoras cumplimientoHoras);
        Task<bool> EliminarCumplimientoHoras(int id);
    }
}
