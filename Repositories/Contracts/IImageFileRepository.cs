using ArgusEyesApi.Entities;

namespace ArgusEyesApi.Repositories.Contracts
{
    public interface IImageFileRepository
    {
        Task<IEnumerable<KundenImagesDaten>> GetAllKundenImages();
        Task<KundenImagesDaten> GetKundenImageById(int id);
    }
}
