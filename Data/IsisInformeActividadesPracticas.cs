using sisdigitalizacion.Model;

namespace sisdigitalizacion.Data
{
    public interface IsisInformeActividadesPracticas
    {
        Task<IEnumerable<InformeActividadesPracticas>> GetAllInformeActividadesPracticas();
        Task<InformeActividadesPracticas> GetDetails(int id);
        Task<IEnumerable<InformeActividadesPracticas>> GetDetailsByUser(int users_id);
  
    }
}
