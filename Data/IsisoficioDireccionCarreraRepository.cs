using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisoficioDireccionCarreraRepository
    {
        
        Task<bool> ActualizarOficioDireccionCarrera(OficioDireccionCarrera oficiodireccioncarrera);
        Task<bool> EliminarOficioDireccionCarrera(int id);
        Task<IEnumerable<OficioDireccionCarrera>> GetAllOficioDireccionCarrera();
        Task<OficioDireccionCarrera> GetDetails(int id);
        Task<IEnumerable<OficioDireccionCarrera>> GetDetailsByUser(int users_id);
        Task<bool> InsertarOficioDireccionCarrera(OficioDireccionCarrera oficiodireccioncarrera);
    }
}
