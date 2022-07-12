using ArgusEyesApi.Entities;

namespace ArgusEyesApi.Repositories.Contracts
{
    public interface IkundenDatenRepository
    {
        Task<IEnumerable<KundenDaten>> GetAllKunden();
        Task<KundenDaten> GetKundenById(int id);
    }
}
