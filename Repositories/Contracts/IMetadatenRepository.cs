using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;

namespace ArgusEyesApi.Repositories.Contracts
{
    public interface IMetadatenRepository
    {
        Task<IEnumerable<Metadaten>> GetAllImagesMetaDaten();
        Task<Metadaten> GetImageMetaDatenById(int id);
        Task<bool> AddImageMetaDaten(KundenImagesMetaDatenDto dto);

    }
}
